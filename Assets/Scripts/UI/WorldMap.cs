using UnityEngine;
using System.Collections;

public class WorldMap : MonoBehaviour {

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
	
	}
	
	void Update () {
	
	}
}
