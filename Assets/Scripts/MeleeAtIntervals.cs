﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeleeAtIntervals : Damage {

    public float hitIntervalSeconds = 5.0f;
    float hitEnergy = 0.0f;
    GameObject target;

    void Start() {
    }

    void Update() {
        if (hitEnergy < hitIntervalSeconds) {
            hitEnergy += Time.deltaTime;
            this.SetIsNotAttacking();

        } else {
            if (target != null) {
                this.SetIsAttacking();
                Hit(target);
            }/* else {
            }*/
        }
    }
    
    void Hit(GameObject target) {
        hitEnergy = 0.0f;
        DoDamage(target);
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Building") {
            target = coll.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.tag == "Building") {
            target = null;
        }
    }
}
