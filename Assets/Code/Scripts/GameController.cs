using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; set; }

    public Vector2 CharacterPosition { get; set; }
    public Dictionary<int, int> Inventory { get; set; }

	void Awake()
    {
        CharacterPosition = new Vector2(-4f, -3.5f);

        Inventory = new Dictionary<int, int>();
        Inventory[140] = 1;

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }	
        else if (Instance != this)
        {
            Destroy(gameObject);
        }    
	}
}
