using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootAtIntervals : MonoBehaviour {

    public Transform projectile;
    public float shotIntervalSeconds = 5.0f;
    public float arrowSpeed = 5.0f;
    public float targetRadius = 4.382293f;
    float shotEnergy = 0.0f;
    List<GameObject> targets;
    GameObject target;
    Vector2 towerPosition;
    AudioSource arrowSound;

	void Start () {
        towerPosition = GetComponent<Rigidbody2D>().position;
        shotEnergy = shotIntervalSeconds;
        arrowSound = GetComponent<AudioSource>();
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
        targets = new List<GameObject>(GameObject.FindGameObjectsWithTag("Monster"));
        float distance = 1000.0f;
        for (int i = 0; i < targets.Count; i++) {
            float dist = (targets[i].GetComponent<Rigidbody2D>().position - towerPosition).magnitude;
            if (dist < targetRadius) {
                newTarget = targets[i];
                distance = dist;
            }
        }

        target = newTarget;
        return target;
    }

    void Shoot(GameObject target) {
        float dist = (target.GetComponent<Rigidbody2D>().position - towerPosition).magnitude;
        if (dist > targetRadius) {
            target = null;
            return;
        }

        arrowSound.PlayOneShot(arrowSound.clip);

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

    void OnDrawGizmos() {
        #if UNITY_EDITOR
        UnityEditor.Handles.DrawWireDisc(gameObject.transform.position, Vector3.back, targetRadius);
        #endif
    }
}
