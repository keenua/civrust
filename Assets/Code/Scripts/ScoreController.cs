using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    Text text;

    private int _score;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            text.text = "Score: " + value;
        }
    }

    // Use this for initialization
    void Start()
    {
        text = GetComponentInParent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
