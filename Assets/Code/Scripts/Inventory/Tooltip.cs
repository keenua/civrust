using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour {

    private Item Item { get; set; }
    private string Data { get; set; }
    private GameObject TooltipObject { get; set; }

    void Start()
    {
        TooltipObject = GameObject.Find("Tooltip");
        Deactivate();
    }

    void Update()
    {
        if (TooltipObject.activeSelf)
        {
            TooltipObject.transform.position = Input.mousePosition;
        }
    }

    public void Activate(Item item)
    {
        Item = item;
        ConstructDataString();
        TooltipObject.SetActive(true);
    }

    public void Deactivate()
    {
        Item = null;
        TooltipObject.SetActive(false);
    }


    public void ConstructDataString()
    {
        if (Item != null)
        {
            Data = "<color=#D4AF37><b>" + Item.Title + "</b></color>\n\n" + Item.Description;
            TooltipObject.GetComponentInChildren<Text>().text = Data;
        }
    }
}
