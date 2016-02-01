using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerInteractions : MonoBehaviour {

    private List<InteractableUnit> InteractionWith { get; set; }

    private void Start()
    {
        InteractionWith = new List<InteractableUnit>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var interactable = collision.gameObject.GetComponent<InteractableUnit>();

        if (interactable != null)
        {
            InteractionWith.Add(interactable);
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

            if (InteractionWith.Any())
                InteractionWith[0].IsHighlighted = true;
        }
    }

    void Update()
    {
        if (InteractionWith.Any())
        {
            if (Input.GetButtonDown("Jump"))
                InteractionWith[0].Interact();
        }
    }

}
