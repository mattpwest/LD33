using System.Security.Cryptography;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Speed = 1;
    private GameObject destination;
    private Rigidbody2D body;

    public void SetDestination(GameObject destination)
    {
        this.destination = destination;
    }

    // Use this for initialization
    private void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (destination == null)
        {
            return;
        }

        Vector2 towards = destination.transform.position - transform.position;

        body.velocity = towards;

        if (transform.position == destination.transform.position)
        {
            destination = null;
        }
    }
}