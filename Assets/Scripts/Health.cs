using UnityEngine;
using System.Collections;

/**
 * Add this to any entity to be able to take damage gradually before being destroyed.
 * 
 * Once health hits 0 this behaviour will destroy the game object.
 */
public class Health : MonoBehaviour {

    public float health = 1.0f;

	void Start () {
	}
	
	void Update () {
        if (health <= 0.0f) {
            Destroy(this.gameObject);
        }
	}

    public void TakeDamage(float damage) {
        health -= damage;
    }
}
