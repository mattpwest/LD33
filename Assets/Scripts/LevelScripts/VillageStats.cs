using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VillageStats : MonoBehaviour
{
    private List<GameObject> buildings;
    private int totalTerror;
    private int currentTerror;

    public int PercentDestroyed
    {
        get
        {
            return currentTerror / totalTerror * 100;
        }
    }

    // Use this for initialization
    private void Start()
    {
        this.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        this.totalTerror = this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);
        this.currentTerror = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        buildings.Remove(null);
        this.currentTerror = this.totalTerror - this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);
    }
}
