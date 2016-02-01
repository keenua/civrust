﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

    public int TimeMax = 15;

    private float TimeStart { get; set; }
    private Text TextField { get; set; }
    private Transform ProgressBar { get; set; }

	// Use this for initialization
	void Start () {
        TimeStart = Time.time;
        TextField = GetComponentInChildren<Text>();
        ProgressBar = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {

        int secondsLeft = TimeMax - Mathf.CeilToInt(Time.time - TimeStart);

        if (secondsLeft <= 0)
        {
            var score = FindObjectOfType<ScoreController>();

            if (!GameController.Instance.Inventory.ContainsKey(126))
                GameController.Instance.Inventory.Add(126, 0);

            GameController.Instance.Inventory[126] += score.Score;
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