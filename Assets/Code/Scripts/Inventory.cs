using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int SlotAmount = 7;
    public GameObject slotPrefab;
    public GameObject itemPrefab;

    private GameObject SlotPanel { get; set; }
    private ItemDatabase ItemDatabase { get; set; }

    public Item[] Items { get; set; }
    public GameObject[] Slots { get; set; }

    private int _selectedIndex;
    public int SelectedIndex
    {
        get { return _selectedIndex; }
        set
        {
            _selectedIndex = value;

            for (int i = 0; i < Slots.Length; i++)
                Slots[i].GetComponent<InventorySlot>().Selected = i == value;
        }
    }

    void Start()
    {
        Items = new Item[SlotAmount];
        Slots = new GameObject[SlotAmount];

        SlotPanel = transform.FindChild("Slot Panel").gameObject;
        ItemDatabase = GetComponent<ItemDatabase>();

        for (int i = 0; i < SlotAmount; i++)
        {
            var slot = Instantiate(slotPrefab);
            slot.GetComponent<InventorySlot>().SlotIndex = i;
            Slots[i] = slot;
            slot.transform.SetParent(SlotPanel.transform);
        }
    }

    public void AddItem(int id)
    {
        var item = ItemDatabase.FetchItemByID(id);

        if (item != null)
        {
            if (item.IsStackable && Items.Any(x => x != null && x.ID == id))
            {
                for (int i = 0; i < Items.Length; i++)
                    if (Items[i].ID == id)
                    {
                        var transform = Slots[i].transform;

                        var data = transform.GetComponentInChildren<ItemData>();
                        data.Amount++;
                        transform.GetComponentInChildren<Text>().text = data.Amount + "";
                        break;
                    }
            }
            else
                for (int i = 0; i < Items.Length; i++)
                {
                    if (Items[i] == null)
                    {
                        Items[i] = item;

                        var itemObj = Instantiate(itemPrefab);
                        var itemData = itemObj.GetComponent<ItemData>();
                        itemData.Item = item;
                        itemData.SlotIndex = i;
                        itemObj.transform.SetParent(Slots[i].transform);
                        itemObj.transform.position = Vector2.zero;
                        itemObj.GetComponent<Image>().sprite = item.Sprite;
                        itemObj.name = item.Title;

                        break;
                    }
                }
        }
    }
}
