using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TreeUnit : InteractableUnit {

    public override bool CanInteractWith(Item item)
    {
        if (item == null) return false;

        return item.ID == Items.Hatchet;
    }

    public override void Interact()
    {
        GameController.Instance.CharacterPosition = FindObjectOfType<WalkerController>().gameObject.transform.position;

        SceneManager.LoadScene("Lumberjack");
    }
}
