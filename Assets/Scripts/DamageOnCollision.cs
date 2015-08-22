using UnityEngine;
using System.Collections;

public class DamageOnCollision : Damage {

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        //Debug.Log("Collided with tag: " + coll.gameObject.tag);
        if (coll.gameObject.tag == "Monster") {
            DoDamage(coll.gameObject);
            Destroy(this.gameObject);
        }
    }
}
