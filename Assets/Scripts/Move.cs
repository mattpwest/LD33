using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private GameObject destination;
    private Rigidbody2D body;
    private bool shouldMove;
    public float Speed = 1;
    public float Accelleration = 1;

    public void FindNewDestination(IEnumerable<GameObject> buildings)
    {
        if(this.destination != null || !this.shouldMove)
        {
            return;
        }

        GameObject closest = null;
        float distance = 0f;

        foreach(var building in buildings)
        {
            float newDistance = Vector2.Distance(this.body.position, building.transform.position);

            if(newDistance >= distance && distance != 0)
            {
                continue;
            }
            distance = newDistance;
            closest = building;
        }

        this.destination = closest;
    }

    private void Start()
    {
        this.body = this.GetComponent<Rigidbody2D>();
        this.SetShouldMove();
    }

    private void Update()
    {
        if(this.destination == null)
        {
            this.SetShouldMove();
            //this.body.velocity = new Vector2(0, 0);
            return;
        }

        Vector2 towards = this.destination.transform.position - this.transform.position;

        if (this.body.velocity.magnitude < Speed) {
            this.body.AddForce(towards.normalized * (Accelleration * this.body.mass / 60.0f));
        }

        //this.body.velocity = towards;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Building" && !coll.isTrigger)
        {
            this.SetShouldNotMove();
        }
    }

    private void SetShouldNotMove()
    {
        this.shouldMove = false;
    }

    private void SetShouldMove()
    {
        this.shouldMove = true;
    }
}
