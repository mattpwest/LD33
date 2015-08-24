using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public void GoWorldMap() {
        Application.LoadLevel(5);
    }

    public void GoQuit() {
        Application.Quit();
    }

	void Start () {
	
	}
	
	void Update () {
	
	}
}
