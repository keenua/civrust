using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class InteractableUnit : MonoBehaviour {

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

    public void Interact()
    {
        GameController.Instance.CharacterPosition = FindObjectOfType<WalkerController>().gameObject.transform.position;

        SceneManager.LoadScene("Lumberjack");
    }
}
