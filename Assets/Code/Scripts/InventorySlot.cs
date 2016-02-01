using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler {

    private Inventory Inventory { get; set; }

    public Sprite DefaultBackground;
    public Sprite SelectedBackground;

    public int SlotIndex { get; set; }

    private bool _selected;
    public bool Selected
    {
        get { return _selected; }
        set
        {
            _selected = value;

            GetComponent<Image>().sprite = value ? SelectedBackground : DefaultBackground;
        }
    }
    
    void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<ItemData>();

        if (item != null)
        {
            if (Inventory.Items[SlotIndex] == null)
            {
                if (Inventory.SelectedIndex == item.SlotIndex)
                    Inventory.SelectedIndex = SlotIndex;

                Inventory.Items[item.SlotIndex] = null;
                Inventory.Items[SlotIndex] = item.Item;
                item.SlotIndex = SlotIndex;
            }
            else if (item.SlotIndex != SlotIndex)
            {
                if (Inventory.SelectedIndex == item.SlotIndex) Inventory.SelectedIndex = SlotIndex;
                else if (Inventory.SelectedIndex == SlotIndex) Inventory.SelectedIndex = item.SlotIndex;

                var currentItem = transform.GetChild(0);
                currentItem.GetComponent<ItemData>().SlotIndex = item.SlotIndex;
                currentItem.transform.SetParent(Inventory.Slots[item.SlotIndex].transform);
                currentItem.transform.position = Inventory.Slots[item.SlotIndex].transform.position;

                item.SlotIndex = SlotIndex;
                item.transform.SetParent(transform);
                item.transform.position = transform.position;

                Inventory.Items[item.SlotIndex] = currentItem.GetComponent<ItemData>().Item;
                Inventory.Items[SlotIndex] = item.Item;
            }
        }
    }
}
