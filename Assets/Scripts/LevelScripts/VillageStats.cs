using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VillageStats : MonoBehaviour
{
    private List<GameObject> buildings;
    private int totalTerror;
    private int currentTerror;
    private GameObject castle;

    private bool GoalFiftyPercent
    {
        get
        {
            return this.PercentDestroyed >= 50;
        }
    }

    private bool GoalHundredPercent
    {
        get
        {
            return this.PercentDestroyed >= 100;
        }
    }

    private bool GoalCastle
    {
        get
        {
            return this.castle == null;
        }
    }

    public int PercentDestroyed
    {
        get
        {
            return (int)Math.Round(this.currentTerror / (float)this.totalTerror * 100);
        }
    }

    public int GoalsAchieved
    {
        get
        {
            int count = 0;
            if(this.GoalFiftyPercent)
            {
                count++;
            }
            if(this.GoalHundredPercent)
            {
                count++;
            }
            if(this.GoalCastle)
            {
                count++;
            }
            return count;
        }
    }

    private void Start()
    {
        this.castle = GameObject.Find("Castle");
        this.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        this.totalTerror = this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);
        this.currentTerror = 0;
    }

    private void Update()
    {
        this.buildings.Where(b => b == null).ToList().ForEach(b => this.buildings.Remove(null));
        this.currentTerror = this.totalTerror - this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);
    }
}
