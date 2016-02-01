using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Assets.Scripts;

public class TreeController : MonoBehaviour {

    public GameObject TreeWithNoBranches;
    public GameObject TreeWithLeftBranch;
    public GameObject TreeWithRightBranch;

    public float FallingSpeed = 0.005f;

    private List<Direction> Tree { get; set; }
    private List<GameObject> TreeParts { get; set; }
    private Vector3[] TreePositions { get; set; }


    Direction RandomTreePart()
    {
        return (Direction)Mathf.Min((int)(Random.value * 3), 2);
    }

	// Use this for initialization
	void Start () {
        Tree = new List<Direction>();
        TreeParts = new List<GameObject>();
        TreePositions = new Vector3[8];

        for (int i = 0; i < TreePositions.Length; i++)
        {
            TreePositions[i] = gameObject.transform.position + new Vector3(0, 1.2f + i * 1.3f);
            Tree.Add(RandomTreePart());

            var treePart = GetTreePartPrefab(Tree[i]);
            TreeParts.Add((GameObject)Instantiate(treePart, TreePositions[i], Quaternion.identity));
        }
	}
    GameObject GetTreePartPrefab(Direction direction)
    {
        switch (direction)
        {
            case Direction.None: return TreeWithNoBranches;
            case Direction.Left: return TreeWithLeftBranch;
            case Direction.Right: return TreeWithRightBranch;
        }

        throw new System.ArgumentException("Invalid direction argument");
    }

    public bool Chop(Direction direction)
    {
        if (Tree[0] == direction) return false;

        Tree.RemoveAt(0);
        Tree.Add(RandomTreePart());

        TreeParts[0].GetComponent<TreePartController>().GetChopped(direction);

        TreeParts.RemoveAt(0);
        TreeParts.Add(GetTreePartPrefab(Tree.Last()));

        var position = gameObject.transform.position + new Vector3(0, 1.2f + (Tree.Count - 1) * 1.3f);

        var treePart = GetTreePartPrefab(Tree.Last());
        TreeParts[Tree.Count - 1] = (GameObject)Instantiate(treePart, position, Quaternion.identity);

        return true;
    }
	
	// Update is called once per frame
	void Update () {
	    for (int i = 0; i < Tree.Count; i++)
        {
            var treePart = TreeParts[i];
            var left = treePart.transform.position.y - TreePositions[i].y;

            if (left <= 0) continue;

            var speed = FallingSpeed * 1f / Time.deltaTime;

            treePart.transform.position -= new Vector3(0, Mathf.Min(left, speed));
        }
	}
}
