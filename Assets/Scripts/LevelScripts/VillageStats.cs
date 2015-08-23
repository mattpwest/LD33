using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class VillageStats : MonoBehaviour
{
    private List<GameObject> buildings;
    private int totalTerror;
    private int currentTerror;
    private bool goalFiftyPercent;
    private bool goalHundredPercent;
    private bool goalCastle;
    private GameObject castle;

    public int PercentDestroyed
    {
        get
        {
            return (int) Math.Round(currentTerror / (float) totalTerror * 100);
        }
    }

    public int GoalsAchieved {
        get {
            int count = 0;
            if (goalFiftyPercent) count++;
            if (goalHundredPercent) count++;
            if (goalCastle) count++;
            return count;
        }
    }

    private void Start()
    {
        this.castle = GameObject.Find("Castle");
        this.buildings = GameObject.FindGameObjectsWithTag("Building").ToList();
        this.totalTerror = this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);
        this.currentTerror = 0;
        this.goalFiftyPercent = false;
        this.goalHundredPercent = false;
        this.goalCastle = false;
    }

    private void Update()
    {
        buildings.Where(b => b == null).ToList().ForEach(b => buildings.Remove(null));
        this.currentTerror = this.totalTerror - this.buildings.Sum(b => b.GetComponent<TerrorSource>().terror);

        if (this.PercentDestroyed >= 50) {
            goalFiftyPercent = true;
        }

        if (this.PercentDestroyed >= 100) {
            goalHundredPercent = true;
        }

        if (castle == null) {
            goalCastle = true;
        }
    }
}
