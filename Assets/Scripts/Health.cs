using UnityEngine;
using System.Collections;

/**
 * Add this to any entity to be able to take damage gradually before being destroyed.
 * 
 * Once health hits 0 this behaviour will destroy the game object.
 */
public class Health : MonoBehaviour {

    public float health = 1.0f;
    float currentHealth = 0.0f;

    public float GetHealth() {
        return currentHealth;
    }

    public float GetHealthPercentage() {
        return currentHealth / health;
    }

	void Start () {
        currentHealth = health;
	}
	
	void Update () {
        if (currentHealth <= 0.0f) {
            Destroy(this.gameObject);
        }
	}

    public void TakeDamage(float damage) {
        currentHealth -= damage;
    }
}
