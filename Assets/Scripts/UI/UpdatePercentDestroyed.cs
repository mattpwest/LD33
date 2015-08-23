using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdatePercentDestroyed : MonoBehaviour {

    UnityEngine.UI.Text textWidget;
    VillageStats villageStats;

	void Start () {
        textWidget = GetComponent<UnityEngine.UI.Text>();
        villageStats = FindObjectOfType<VillageStats>();
	}
	
	void Update () {
        textWidget.text = string.Format("{0}%", villageStats.PercentDestroyed);
	}
}
