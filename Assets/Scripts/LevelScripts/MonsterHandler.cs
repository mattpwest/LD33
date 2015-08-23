using System.Linq;
using UnityEngine;

public class MonsterHandler : MonoBehaviour
{
    private void Start() {}

    private void Update()
    {
        var buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        var units = GameObject.FindGameObjectsWithTag("Monster").ToList();

        foreach(var unit in units)
        {
            unit.GetComponent<Move>().FindNewDestination(buildings);
        }
    }
}
