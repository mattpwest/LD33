using UnityEngine;
using System.Collections;

/**
 * Use this behaviour on anything that needs to deal damage to objects with Health.
 */
public class Damage : MonoBehaviour {

    public float damage = 1.0f;
    public bool IsAttacking { get; private set; }

	void Start () {
	    
	}
	
	void Update () {
	
	}

    public virtual void DoDamage (GameObject target) {
        target.GetComponent<Health>().TakeDamage(damage);
    }

    protected void SetIsAttacking()
    {
        this.IsAttacking = true;
    }

    protected void SetIsNotAttacking()
    {
        this.IsAttacking = false;
    }
}
