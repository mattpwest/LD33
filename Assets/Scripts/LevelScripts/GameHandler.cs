using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private VillageStats villageStats;
    private Clock clock;
    public GameObject VillageStats;
    public GameObject Clock;

    private bool HasTimeRunOut
    {
        get
        {
            return this.clock.HasTimeRunOut;
        }
    }

    private bool HasAllBuildingsBeenDestroyed
    {
        get
        {
            return this.villageStats.PercentDestroyed == 100;
        }
    }

    // Use this for initialization
    private void Start()
    {
        this.villageStats = this.VillageStats.GetComponent<VillageStats>();
        this.clock = this.Clock.GetComponent<Clock>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(this.HasTimeRunOut || this.HasAllBuildingsBeenDestroyed)
        {
            Application.LoadLevel(0);
        }
    }
}
