using UnityEngine;
using System.Collections;

public class QuitOnEscape : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
