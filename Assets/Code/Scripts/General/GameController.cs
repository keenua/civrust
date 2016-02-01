using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;

public class GameController : MonoBehaviour {

    public static GameController Instance { get; set; }

    public Vector2 CharacterPosition { get; set; }
    public Dictionary<Items, int> Inventory { get; set; }
    public Map Map { get; set; }

    void InitializeState()
    {
        CharacterPosition = new Vector2(-4f, -3.5f);

        Inventory = new Dictionary<Items, int>();
        Inventory[Items.Hatchet] = 1;
        Inventory[Items.Wood] = 5;

        Map = new Map();

        var vectors = new List<Vector2>();

        for (int i = 0; i < 20; i++)
        {
            Vector2 v;

            do
            {
                v = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            }
            while (vectors.Any(x => Vector2.Distance(v, x) < 0.5f));

            vectors.Add(v);
        }

        foreach (var p in vectors.OrderBy(x => x.y))
            Map.AddObject(MapObjectType.Tree, p.x, p.y);
    }

	void Awake()
    {
        InitializeState();

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
