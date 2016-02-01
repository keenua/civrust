using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MapController : MonoBehaviour {

    public GameObject[] Trees;
    public GameObject[] Stones;
    public GameObject[] Barrels;

    private Inventory Inventory { get; set; }
    private GameObject Player { get; set; }
    
	// Use this for initialization
	void Start () {
        Inventory = FindObjectOfType<Inventory>();
        Player = FindObjectOfType<WalkerController>().gameObject;

        foreach (var m in GameController.Instance.Map.Objects)
            if (m.ObjectType == MapObjectType.Tree)
                Instantiate(Trees[m.Seed % Trees.Length], m.Position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
