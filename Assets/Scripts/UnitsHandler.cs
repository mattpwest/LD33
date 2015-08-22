using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitsHandler : MonoBehaviour
{
    private List<GameObject> units;
    private List<GameObject> buildings;
    public GameObject BuildingsParent;

    // Use this for initialization
    private void Start()
    {
        this.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        this.units = GameObject.FindGameObjectsWithTag("Monster").ToList();
    }

    // Update is called once per frame
    private void Update()
    {
        this.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        this.units = GameObject.FindGameObjectsWithTag("Monster").ToList();

        foreach(var unit in this.units)
        {
            Vector2 position = unit.GetComponent<Rigidbody2D>().position;

            unit.GetComponent<Move>().SetDestination(this.GetDistanceFrom(position));
        }
    }

    private void RemoveKilledUnits() {
        List<GameObject> dead = this.units.Where(unit => unit == null).ToList();

        dead.ForEach(d => units.Remove(d));
    }

    private GameObject GetDistanceFrom(Vector2 position)
    {
        GameObject closest = null;
        float distance = 0f;

        foreach(var building in buildings)
        {
            float newDistance = Vector2.Distance(position, building.transform.position);

            if(newDistance >= distance && distance != 0)
            {
                continue;
            }
            distance = newDistance;
            closest = building;
        }

        return closest;
    }
}
