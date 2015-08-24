using UnityEngine;
using System.Collections;

public class MonsterAttack : MonoBehaviour
{

    public AudioSource source;
    private Damage monsterDamage;

	// Use this for initialization
	void Start ()
	{
	    this.monsterDamage = gameObject.GetComponent<Damage>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(monsterDamage.IsAttacking)
	    {
	        source.PlayOneShot(source.clip);
	    }
	}
}
