using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class InteractableUnit : MonoBehaviour {

    private bool _isHighlighted;
    public bool IsHighlighted
    {
        get { return _isHighlighted; }
        set
        {
            _isHighlighted = value;
            GetComponent<SpriteRenderer>().color = value ? Color.black : Color.white;
        }
    }

    public abstract bool CanInteractWith(Item item);
    public abstract void Interact();
}
