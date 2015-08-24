using System.Linq;
using UnityEngine;
using Random = System.Random;

public class MonsterAttack : MonoBehaviour
{
    private Damage monsterDamage;
    private Random random;
    public AudioSource Source;
    public AudioClip[] Clips;

    // Use this for initialization
    private void Start()
    {
        this.monsterDamage = this.gameObject.GetComponent<Damage>();
        this.random = new Random();
    }

    // Update is called once per frame
    private void Update()
    {
        if(this.monsterDamage.IsAttacking)
        {
            var clipIndex = this.random.Next(this.Clips.Count());
            this.Source.PlayOneShot(this.Clips[clipIndex]);
        }
    }
}
