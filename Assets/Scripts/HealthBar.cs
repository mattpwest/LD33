using UnityEngine;
using System.Collections;

/**
 * Adds a health bar to a unit, keeps it positioned above the unit and
 * destroys it when the unit is destroyed.
 */
public class HealthBar : MonoBehaviour {

    /** HealthBar prefab to use. */
    public GameObject healthBar;
    GameObject healthBarInstance;
    Transform healthValueBar;
    Rigidbody2D body;
    Health health;
    float heightOffset = 0.0f;

	void Start () {
        body = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        healthBarInstance = (GameObject) Instantiate(healthBar, body.position, Quaternion.identity);
        healthValueBar = healthBarInstance.transform.FindChild("HealthValue");
        float top = gameObject.GetComponent<SpriteRenderer>().bounds.max.y;
        float height = healthBarInstance.GetComponent<SpriteRenderer>().bounds.size.y;
        heightOffset = top + height;
        UpdatePosition();
	}
	
	void Update () {
        UpdatePosition();
        UpdateHealth();
	}

    void UpdatePosition() {
        // Initial position centered in the unit
        Vector3 newPos = new Vector3(body.position.x, body.position.y, 0);
        healthBarInstance.transform.position = newPos;

        // Adjust Y to be above the unit
        SpriteRenderer barRenderer = healthBarInstance.GetComponent<SpriteRenderer>();
        SpriteRenderer unitRenderer = GetComponent<SpriteRenderer>();
        var newY = unitRenderer.bounds.max.y + barRenderer.bounds.size.y * 1.1f;
        newPos = new Vector3(newPos.x, newY, newPos.z);
        healthBarInstance.transform.position = newPos;
    }

    void UpdateHealth() {
        SpriteRenderer barRenderer = healthValueBar.GetComponent<SpriteRenderer>();
        float oldX = barRenderer.bounds.min.x;
        healthValueBar.transform.localScale = new Vector3(health.GetHealthPercentage(), 1.0f, 1.0f);
        float newX = barRenderer.bounds.min.x;
        float xChange = newX - oldX;
        healthValueBar.transform.position = new Vector3(
            healthValueBar.transform.position.x - xChange,
            healthValueBar.transform.position.y,
            healthValueBar.transform.position.z
        );
    }

    void OnDestroy() {
        Destroy(healthBarInstance);
    }
}
