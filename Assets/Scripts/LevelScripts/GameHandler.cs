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
        //Player player = (Player)reader.Deserialize(typeof(Player));
        var player = new Player { CurrentLevel = 0 };

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


        var playerJson = JsonWriter.Serialize(player);

        var playerDes = JsonReader.Deserialize<Player>(playerJson);

        return player;
    }
}
