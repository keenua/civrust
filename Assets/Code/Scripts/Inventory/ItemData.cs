using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public Item Item { get; set; }
    public int Amount { get; set; }
    public int SlotIndex { get; set; }

    private Inventory Inventory { get; set; }
    private Tooltip Tooltip { get; set; }
    private Vector2 Offset { get; set; }

    public ItemData()
    {
        Amount = 1;
    }

    void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
        Tooltip = FindObjectOfType<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Item != null)
        {
            transform.SetParent(transform.parent.parent);
            transform.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Item != null)
            transform.position = eventData.position - Offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var slot = Inventory.Slots[SlotIndex];
        transform.SetParent(slot.transform);
        transform.position = slot.transform.position;
        transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Item != null)
        {
            Offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
            transform.position = eventData.position - Offset;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Activate(Item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Deactivate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Inventory.SelectedIndex = SlotIndex;
    }
}

