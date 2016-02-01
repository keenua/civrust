using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using System.Linq;

public enum Items
{
    Wood = 126,
    Hatchet = 140
}

public class ItemDatabase : MonoBehaviour {

    private List<Item> Items { get; set; }

    void Start()
    {
        var path = Application.dataPath + "/StreamingAssets/items.json";
        var text = File.ReadAllText(path);
        var reader = new JsonReader();

        var sprites = Resources.LoadAll<Sprite>("Sprites/Inventory/Items/items");

        Items = reader.Read<Item[]>(text).ToList();
        foreach (var i in Items)
            i.Sprite = sprites.FirstOrDefault(x => x.name == "items_" + (int)i.ID);
    }

    public Item FetchItemByID(Items id)
    {
        return Items.FirstOrDefault(x => x.ID == id);
    }
}

public class Item
{
    public Items ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public bool IsStackable { get; set; }
    public Sprite Sprite { get; set; }
}
