using UnityEngine;
using System.Collections;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
