using UnityEngine;
using Assets.Scripts.Persistence;
using System.Collections;

public class WorldMap : MonoBehaviour {

    private readonly Files files = new Files();
    private readonly JSON<Player> json = new JSON<Player>();
    Player player;

    public void GoMainMenu() {
        Application.LoadLevel(0);
    }

    public void GoLevel1() {
        Application.LoadLevel(1);
    }

    public void GoLevel2() {
        Application.LoadLevel(2);
    }

    public void GoLevel3() {
        Application.LoadLevel(3);
    }

    public void GoLevel4() {
        Application.LoadLevel(4);
    }

	void Start () {
        player = LoadPlayer();

        GameObject lvl1 = GameObject.Find("Level1");
        GameObject lvl2 = GameObject.Find("Level2");
        GameObject lvl3 = GameObject.Find("Level3");
        GameObject lvl4 = GameObject.Find("Level4");

        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        lvl4.SetActive(false);

        if (player.CurrentLevel >= 0) {
            lvl1.SetActive(true);
        }

        if (player.CurrentLevel >= 1) {
            lvl2.SetActive(true);
        }

        if (player.CurrentLevel >= 2) {
            lvl3.SetActive(true);
        }

        if (player.CurrentLevel >= 3) {
            lvl4.SetActive(true);
        }
	}
	
	void Update () {
	}

    private Player LoadPlayer() {
        var information = this.files.ReadFile("Player.json");

        return string.IsNullOrEmpty(information) ? this.NewEmptyPlayer() : this.json.Deserialize(information);
    }

    private Player NewEmptyPlayer() {
        return new Player();
    }
}
