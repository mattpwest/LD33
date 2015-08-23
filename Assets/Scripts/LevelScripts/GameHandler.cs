using System.IO;
using Assets.Scripts.Persistence;
using Pathfinding.Serialization.JsonFx;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private VillageStats villageStats;
    private Clock clock;
    private Player player;

    public GameObject VillageStats;
    public GameObject Clock;
    public int CurrentLevel = 1;
    public bool IsTesting = true;

    private int NextLevel
    {
        get
        {
            return CurrentLevel + 1;
        }
    }

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

    private string ReadFile(string fileName)
    {
        if(!File.Exists(fileName))
        {
            return string.Empty;
        }

        var contents = File.ReadAllText(fileName);

        return contents;
    }

    private void WriteFile(string fileName, string contents)
    {
        File.WriteAllText(fileName, contents);
    }

    // Use this for initialization
    private void Start()
    {
        this.villageStats = this.VillageStats.GetComponent<VillageStats>();
        this.clock = this.Clock.GetComponent<Clock>();

        this.player = this.LoadPlayer();

        if(this.IsTesting)
        {
            return;
        }
        this.CurrentLevel = this.player.CurrentLevel;
    }

    // Update is called once per frame
    private void Update()
    {
        this.CheckIfGameShouldEnd();
    }

    private void CheckIfGameShouldEnd()
    {
        if(this.HasAllBuildingsBeenDestroyed)
        {
            this.AllBuildingsDestroyedEnd();
        }
        else if(this.HasTimeRunOut)
        {
            this.TimeHasRunOutEnd();
        }
    }

    private void AllBuildingsDestroyedEnd()
    {
        this.player.CurrentLevel = this.NextLevel;
        this.player.UpdateLevelStats(this.CurrentLevel, this.villageStats.GoalsAchieved);
        this.SavePlayer();
        Application.LoadLevel(this.NextLevel);
    }

    private void TimeHasRunOutEnd()
    {
        Application.LoadLevel(0);
    }

    private Player LoadPlayer()
    {
        var information = this.ReadFile("Player.json");

        return string.IsNullOrEmpty(information) ? this.NewEmptyPlayer() : this.Deserialize(information);
    }

    private void SavePlayer()
    {
        var information = this.Serialize(this.player);

        this.WriteFile("Player.json", information);
    }

    private Player Deserialize(string json)
    {
        return JsonReader.Deserialize<Player>(json);
    }

    private Player NewEmptyPlayer()
    {
        return new Player
               {
                   CurrentLevel = this.CurrentLevel
               };
    }

    private string Serialize(Player player)
    {
        return JsonWriter.Serialize(player);
    }
}
