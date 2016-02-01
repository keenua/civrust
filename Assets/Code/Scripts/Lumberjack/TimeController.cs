using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

    public int TimeMax = 15;

    private float? TimeStart { get; set; }
    private Text TextField { get; set; }
    private Transform ProgressBar { get; set; }

    public void Launch()
    {
        if (TimeStart == null)
            TimeStart = Time.time;
    }

	// Use this for initialization
	void Start () {
        TextField = GetComponentInChildren<Text>();
        ProgressBar = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {

        if (TimeStart == null) return;

        int secondsLeft = TimeMax - Mathf.CeilToInt(Time.time - TimeStart.Value);

        if (secondsLeft <= 0)
        {
            var score = FindObjectOfType<ScoreController>();

            if (!GameController.Instance.Inventory.ContainsKey(Items.Wood))
                GameController.Instance.Inventory.Add(Items.Wood, 0);

            GameController.Instance.Inventory[Items.Wood] += score.Score;
            SceneManager.LoadScene("Main");
            return;
        }

        var nodesToRemove = ProgressBar.childCount - secondsLeft;

        for (int i = 0; i < nodesToRemove; i++)
        {
            var child = ProgressBar.GetChild(ProgressBar.childCount - 1 - i);
            Destroy(child.gameObject);
        }

        TextField.text = secondsLeft + "";
	}
}
