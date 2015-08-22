using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootAtIntervals : MonoBehaviour {

    public Transform projectile;
    public float shotIntervalSeconds = 5.0f;
    public float arrowSpeed = 5.0f;
    float shotEnergy = 0.0f;
    List<GameObject> targets;
    GameObject target;

	void Start () {
        targets = new List<GameObject>();
	}
	
	void Update () {
        if (shotEnergy < shotIntervalSeconds) {
            shotEnergy += Time.deltaTime;
        } else {
            GameObject shotTarget = FindTarget();

            if (shotTarget != null) {
                Shoot(target);
            }
        }
	}

    GameObject FindTarget() {
        if (target != null) {
            return target;
        }

        GameObject newTarget = null;
        for (int i = 0; i < targets.Count; i++) {
            if (newTarget == null) {
                newTarget = targets[i];
                continue;
            } else {
                // TODO: Compare and decide which is the better target
            }
        }

        target = newTarget;
        return target;
    }

    void Shoot(GameObject target) {
        shotEnergy = 0.0f;
        Rigidbody2D towerBody = this.gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D targetBody = target.GetComponent<Rigidbody2D>();
        Vector3 direction = targetBody.position - towerBody.position;    

        Transform arrow = (Transform) Instantiate(projectile, towerBody.position, Quaternion.identity);
        ConstantVelocity arrowMovement = arrow.GetComponent<ConstantVelocity>();
        arrowMovement.SetVelocity(direction.normalized * arrowSpeed);

        // TODO: Fix arrow rotation
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Monster") {
            targets.Add(coll.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Monster") {
            targets.Remove(coll.gameObject);
        }
    }
}
