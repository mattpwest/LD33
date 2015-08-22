using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterHandler : MonoBehaviour
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
            unit.GetComponent<Move>().FindNewDestination(this.buildings);
        }
    }

    private void RemoveKilledUnits() {
        List<GameObject> dead = this.units.Where(unit => unit == null).ToList();

        dead.ForEach(d => units.Remove(d));
    }
}
