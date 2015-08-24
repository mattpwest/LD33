using UnityEngine;
using System.Collections;

public class RotateToVelocity : MonoBehaviour {

	Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
        UpdateRotation();
	}
	
	void Update () {
        UpdateRotation();
	}

	public void UpdateRotation() {
        // Prevent defaulting to no rotation when stopped
        if (body.velocity.magnitude < 0.01f) {
            return;
        }

        var direction = ((body.position + body.velocity) - body.position);
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		body.rotation = angle;
	}
}
