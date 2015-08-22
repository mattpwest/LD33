using UnityEngine;
using System.Collections;

public class ConstantVelocity : MonoBehaviour {

    public Vector2 velocity = new Vector2(0.0f, 5.0f);

	void Start () {
        SetVelocity(velocity);
	}
	
	void Update () {
	}

    public void SetVelocity(Vector2 v) {
        velocity = v;
        GetComponent<Rigidbody2D>().velocity = v;
    }
}
