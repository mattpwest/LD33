using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public Transform Monster;
    private Camera cam;
    private List<BoxCollider2D> spawns;

    // Use this for initialization
    private void Start()
    {
        this.cam = Camera.main;
        this.spawns = GameObject.FindGameObjectsWithTag("Spawn").Select(go => go.GetComponent<BoxCollider2D>()).ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.SpawnOnPosition(Input.mousePosition);
        }
    }

    private void SpawnOnPosition(Vector3 mousePosition)
    {
        var worldPosition = this.cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, this.cam.transform.position.z));

        if (this.spawns.Any(s => s.OverlapPoint(worldPosition)))
        {
            Instantiate(Monster, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
        }
    }
}
