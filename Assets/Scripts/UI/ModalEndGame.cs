using UnityEngine;
using System.Collections;

public class ModalEndGame : MonoBehaviour {

    GameHandler gameHandler;

    public void WorldMap() {
        gameHandler.SavePlayer();
        Application.LoadLevel(5);
    }

    public void RetryLevel() {
        Application.LoadLevel(gameHandler.CurrentLevel);
    }

    public void NextLevel() {
        gameHandler.SavePlayer();
        Application.LoadLevel(5);
    }

    void Start() {
        gameObject.SetActive(false);
        gameHandler = GameObject.FindObjectOfType<GameHandler>();
    }

    void Update() {

    }
}
