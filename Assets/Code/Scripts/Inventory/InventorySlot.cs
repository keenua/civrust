using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler {

    private Inventory Inventory { get; set; }
    private PlayerInteractions PlayerInteractions { get; set; }

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
        PlayerInteractions = FindObjectOfType<PlayerInteractions>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedItem = eventData.pointerDrag.GetComponent<ItemData>();

        if (draggedItem != null)
        {
            if (Inventory.Items[SlotIndex] == null)
            {
                if (Inventory.SelectedIndex == draggedItem.SlotIndex)
                    Inventory.SelectedIndex = SlotIndex;

                Inventory.Items[draggedItem.SlotIndex] = null;
                Inventory.Items[SlotIndex] = draggedItem.Item;
                draggedItem.SlotIndex = SlotIndex;
            }
            else if (draggedItem.SlotIndex != SlotIndex)
            {
                if (Inventory.SelectedIndex == draggedItem.SlotIndex) Inventory.SelectedIndex = SlotIndex;
                else if (Inventory.SelectedIndex == SlotIndex) Inventory.SelectedIndex = draggedItem.SlotIndex;

                var draggedFromIndex = draggedItem.SlotIndex;
                
                var itemInCurrentSlot = transform.GetChild(0);
                itemInCurrentSlot.GetComponent<ItemData>().SlotIndex = draggedItem.SlotIndex;
                itemInCurrentSlot.transform.SetParent(Inventory.Slots[draggedItem.SlotIndex].transform);
                itemInCurrentSlot.transform.position = Inventory.Slots[draggedItem.SlotIndex].transform.position;

                draggedItem.SlotIndex = SlotIndex;
                draggedItem.transform.SetParent(transform);
                draggedItem.transform.position = transform.position;

                Inventory.Items[draggedFromIndex] = itemInCurrentSlot.GetComponent<ItemData>().Item;
                Inventory.Items[SlotIndex] = draggedItem.Item;
            }

            PlayerInteractions.UpdateHighlight();
        }
    }
}
