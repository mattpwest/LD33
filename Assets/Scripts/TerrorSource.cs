using UnityEngine;
using System.Collections;

public class TerrorSource : MonoBehaviour {

    public int terror = 1;
    TerrorBank bank;

	void Start () {
        bank = GameObject.FindObjectOfType<TerrorBank>();
	}
	
	void Update () {
	
	}

    void OnDestroy() {
        bank.AddTerror(terror);
    }
}
