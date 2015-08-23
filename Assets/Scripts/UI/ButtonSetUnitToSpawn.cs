using UnityEngine;
using System.Collections;

public class ButtonSetUnitToSpawn : MonoBehaviour {

    Transform monster;
    SpawnOnClick unitSpawn;

	void Start () {
        monster = GetComponent<ButtonUpdateUnitCost>().monster;
        unitSpawn = GameObject.Find("UnitSpawn").GetComponent<SpawnOnClick>();
	}
	
	void Update () {
	}

    public void SwitchMonster() {
        unitSpawn.SelectMonster(monster);
    }
}
