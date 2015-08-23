using System.IO;
using Assets.Scripts.Persistence;
using Pathfinding.Serialization.JsonFx;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private VillageStats villageStats;
    private Clock clock;

    public GameObject VillageStats;
    public GameObject Clock;
    public int CurrentLevel;

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
    }

    // Update is called once per frame
    private void Update()
    {
        this.CheckIfGameShouldEnd();
    }

    private void CheckIfGameShouldEnd()
    {
        if(!this.HasTimeRunOut && !this.HasAllBuildingsBeenDestroyed)
        {
            return;
        }
        this.BuildPlayerInfo();
        Application.LoadLevel(0);
    }

    private Player BuildPlayerInfo()
    {
        Player player = null;
        var information = this.ReadFile("Player.json");
        if(string.IsNullOrEmpty(information))
        {
            player = new Player { CurrentLevel = 0 };

            player.Levels.Add(new Level
                              {
                                  LevelNumber = this.CurrentLevel,
                                  TerrorRating = 4
                              });
            player.Levels.Add(new Level
                              {
                                  LevelNumber = this.CurrentLevel,
                                  TerrorRating = 0
                              });
        }
        else
        {
            player = JsonReader.Deserialize<Player>(information);
        }

        information = JsonWriter.Serialize(player);

        this.WriteFile("Player.json", information);

        return player;
    }
}
