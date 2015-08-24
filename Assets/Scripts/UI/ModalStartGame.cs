using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ModalStartGame : MonoBehaviour {

    Clock clock;
    UnityEngine.UI.Text textWidget;

    public void StartGame() {
        gameObject.SetActive(false);

        clock.StartClock();
    }

    public void WorldMap() {
        Application.LoadLevel(5);
    }

	void Start () {
        clock = GameObject.FindObjectOfType<Clock>();
        GameHandler gameHandler = GameObject.FindObjectOfType<GameHandler>();
        gameObject.transform.FindChild("Title").GetComponent<UnityEngine.UI.Text>().text = "Level " + gameHandler.CurrentLevel;
	}
	
	void Update () {
	
	}
}
