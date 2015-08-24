using UnityEngine;
using System.Collections;

public class ModalStartGame : MonoBehaviour {

    Clock clock;

    public void StartGame() {
        gameObject.SetActive(false);
        clock.StartClock();
    }

    public void WorldMap() {
        Application.LoadLevel(5 + 1); // Woohoo - release night: hardcoding FTW! :P
    }

	void Start () {
        clock = GameObject.FindObjectOfType<Clock>();
	}
	
	void Update () {
	
	}
}
