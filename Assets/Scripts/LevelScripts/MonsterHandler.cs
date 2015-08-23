using System.Linq;
using UnityEngine;

public class MonsterHandler : MonoBehaviour
{
    // Use this for initialization
    private void Start() {}

    // Update is called once per frame
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
