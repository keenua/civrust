using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerInteractions : MonoBehaviour {

    private List<InteractableUnit> InteractionWith { get; set; }
    private Inventory Inventory { get; set; }

    void Awake()
    {
        InteractionWith = new List<InteractableUnit>();
    }

    void Start()
    {
        Inventory = FindObjectOfType<Inventory>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var interactable = collision.gameObject.GetComponent<InteractableUnit>();
        
        if (interactable != null)
        {
            InteractionWith.Add(interactable);

            if (interactable.CanInteractWith(Inventory.SelectedItem))
                InteractionWith[0].IsHighlighted = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        var interactable = collision.gameObject.GetComponent<InteractableUnit>();

        if (interactable != null)
        {
            InteractionWith.Remove(interactable);
            interactable.IsHighlighted = false;

            var canBeInteracted = InteractionWith.FirstOrDefault(x => x.CanInteractWith(Inventory.SelectedItem));

            if (canBeInteracted != null)
                canBeInteracted.IsHighlighted = true;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            var canBeInteracted = InteractionWith.FirstOrDefault(x => x.CanInteractWith(Inventory.SelectedItem));

            if (canBeInteracted != null)
                canBeInteracted.Interact();
        }
    }

    public void UpdateHighlight()
    {
        if (Inventory == null) return;

        foreach (var i in InteractionWith)
            i.IsHighlighted = false;

        var canBeInteracted = InteractionWith.FirstOrDefault(x => x.CanInteractWith(Inventory.SelectedItem));

        if (canBeInteracted != null)
            canBeInteracted.IsHighlighted = true;
    }
}
