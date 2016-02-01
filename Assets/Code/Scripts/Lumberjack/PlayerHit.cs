using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PlayerHit : MonoBehaviour {

    Animator animator;
    TreeController treeController;
    ScoreController scoreController;
    TimeController timeController;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        treeController = FindObjectOfType<TreeController>();
        scoreController = FindObjectOfType<ScoreController>();
        timeController = FindObjectOfType<TimeController>();
	}

	// Update is called once per frame
	void Update () {

	    if (Input.GetButtonDown("Left"))
        {
            timeController.Launch();        

            gameObject.transform.position = new Vector3(-1.2f, gameObject.transform.position.y);
            animator.SetTrigger("HitRight");
            if (treeController.Chop(Direction.Left))
                scoreController.Score++;
            else scoreController.Score = 0;
        }
        else if (Input.GetButtonDown("Right"))
        {
            timeController.Launch();

            gameObject.transform.position = new Vector3(1.2f, gameObject.transform.position.y);
            animator.SetTrigger("HitLeft");
            if (treeController.Chop(Direction.Right))
                scoreController.Score++;
            else scoreController.Score = 0;
        }
	}
}
