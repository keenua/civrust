using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TreePartController : MonoBehaviour {

    Direction direction;
    float start;

	// Use this for initialization
	void Start () {
        
	}

    // Update is called once per frame
    void Update() {
        if (direction != Direction.None)
        {
            if (start == 0)
                start = Time.time;
            else if (Time.time - start > 2)
            {
                Destroy(gameObject);
                return;
            }

            var x = 15.1f;
            if (direction == Direction.Right) x *= -1;

            transform.position += new Vector3(x, 0) * Time.deltaTime;
            transform.Rotate(new Vector3(0, 0, x));
        }
    }

    public void GetChopped(Direction direction)
    {
        this.direction = direction;
    }
}
