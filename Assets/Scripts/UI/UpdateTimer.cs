using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class UpdateTimer : MonoBehaviour {
    UnityEngine.UI.Text textWidget;
    Clock clock;

    void Start() {
        textWidget = GetComponent<UnityEngine.UI.Text>();
        clock = FindObjectOfType<Clock>();
    }

    void Update() {
        int totalRemaining = (int) Math.Round(clock.TimeLeft);
        int minutes = totalRemaining / 60;
        int seconds = totalRemaining % 60;
        textWidget.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
