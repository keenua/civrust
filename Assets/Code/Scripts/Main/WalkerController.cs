using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WalkerController : MonoBehaviour {

    Rigidbody2D rigidBody;
    Animator animator;
    
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        gameObject.transform.position = GameController.Instance.CharacterPosition;
        var inventory = FindObjectOfType<Inventory>();
        foreach (var item in GameController.Instance.Inventory)
            for (int i = 0; i < item.Value; i++)
                inventory.AddItem(item.Key);
    }

    // Update is called once per frame
    void Update () {

        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (input != Vector2.zero)
        {
            animator.SetBool("iswalking", true);
            animator.SetFloat("input_x", input.x);
            animator.SetFloat("input_y", input.y);
        }
        else
        {
            animator.SetBool("iswalking", false);
        }

        rigidBody.MovePosition(rigidBody.position + input * Time.deltaTime);
    }
}
