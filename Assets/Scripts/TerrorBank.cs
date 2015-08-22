using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TerrorBank : MonoBehaviour {

    public int initialTerror = 30;
    int terror = 0;
    UnityEngine.UI.Text text;

	void Start () {
        terror = initialTerror;
        text = GameObject.Find("TerrorText").GetComponent<UnityEngine.UI.Text>();
	}
	
	void Update () {
        text.text = string.Format("{0,3}", terror);
	}

    public void AddTerror(int terrification) {
        terror += terrification;
    }

    public bool UseTerror(int terrorRequired) {
        if (terrorRequired > terror) {
            return false;
        } else {
            terror -= terrorRequired;
            return true;
        }
    }

    public int GetTerror() {
        return terror;
    }
}
