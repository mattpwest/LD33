using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonUpdateUnitCost : MonoBehaviour {

    public Transform monster;

	void Start () {

        UnityEngine.UI.Text textWidget = GetComponentInChildren<UnityEngine.UI.Text>();
        int cost = monster.GetComponent<TerrorCost>().cost;
        string name = monster.GetComponent<MonsterName>().name;

        textWidget.text = string.Format("{0}\n{1}", name, cost);
	}
	
	void Update () {
	}
}
