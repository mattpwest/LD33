using UnityEngine;
using System.Collections;

/**
 * Use this behaviour on anything that needs to deal damage to objects with Health.
 */
public class Damage : MonoBehaviour {

    public float damage = 1.0f;

	void Start () {
	    
	}
	
	void Update () {
	
	}

    public virtual void DoDamage (GameObject target) {
        target.GetComponent<Health>().TakeDamage(damage);
    }
}
