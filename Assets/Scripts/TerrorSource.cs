using UnityEngine;
using System.Collections;

public class TerrorSource : MonoBehaviour {

    public int terror = 1;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnDestroy() {
        GameObject.FindObjectOfType<TerrorBank>().AddTerror(terror);
    }
}
