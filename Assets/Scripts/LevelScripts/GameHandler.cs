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

        var playerString = this.ReadFile("Player.json");

        this.player = this.BuildPlayerInfo();

        if(this.IsTesting || string.IsNullOrEmpty(playerString))
        {
            return;
        }
        this.CurrentLevel = this.Deserialize(playerString).CurrentLevel;
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
        this.player.CurrentLevel = this.CurrentLevel + 1;
        Application.LoadLevel(this.CurrentLevel + 1);
    }

    private void TimeHasRunOutEnd()
    {
        Application.LoadLevel(0);
    }

    private Player BuildPlayerInfo()
    {
        var information = this.ReadFile("Player.json");
        var player = string.IsNullOrEmpty(information) ? this.NewEmptyPlayer() : this.Deserialize(information);

        player.UpdateLevelStats(this.CurrentLevel, this.villageStats.GoalsAchieved);

        information = this.Serialize(player);

        this.WriteFile("Player.json", information);

        return player;
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
