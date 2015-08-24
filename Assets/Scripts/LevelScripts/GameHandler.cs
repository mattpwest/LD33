using System.Linq;
using Assets.Scripts.Persistence;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private readonly Files files = new Files();
    private readonly JSON<Player> json = new JSON<Player>();
    private VillageStats villageStats;
    private Clock clock;
    private Player player;
    private TerrorBank terrorBank;

    public GameObject gameEndModal;
    public GameObject VillageStats;
    public GameObject Clock;
    public GameObject TerrorBank;
    public int CurrentLevel = 1;
    public int ExtraTerror = 0;
    public bool IsTesting = true;

    private int NextLevel
    {
        get
        {
            return this.IsTesting ? this.CurrentLevel : this.CurrentLevel + 1;
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

    private bool HasPositiveTerrorRating
    {
        get
        {
            return this.villageStats.GoalsAchieved > 0;
        }
    }

    private bool HasPlayerRanOutOfTerror
    {
        get
        {
            return !this.terrorBank.HasTerrorLeft && !GameObject.FindGameObjectsWithTag("Monster").Any();
        }
    }

    // Use this for initialization
    private void Start()
    {
        this.villageStats = this.VillageStats.GetComponent<VillageStats>();
        this.clock = this.Clock.GetComponent<Clock>();
        this.terrorBank = this.TerrorBank.GetComponent<TerrorBank>();

        this.player = this.LoadPlayer();

        if(this.IsTesting)
        {
            this.terrorBank.AddTerror(this.ExtraTerror);
            return;
        }
        var extraTerror = this.player.Levels
            .Where(l => l.LevelNumber < this.CurrentLevel)
            .Sum(l => l.TerrorRating);
        this.terrorBank.AddTerror(extraTerror);
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
            this.EndLevel();
        }
        else if(this.HasPlayerRanOutOfTerror)
        {
            this.EndLevel();
        }
    }

    private void AllBuildingsDestroyedEnd()
    {
        /*
        this.player.UpdateLevelStats(this.CurrentLevel, this.villageStats.GoalsAchieved);
        this.SavePlayer();
        this.LoadNextLevel();
         */
        EndLevel();
    }

    private void EndLevel()
    {
        clock.StopClock();
        gameEndModal.SetActive(true);

        if (this.HasPositiveTerrorRating) {
            gameEndModal.transform.FindChild("ButtonNext").gameObject.SetActive(true);
        } else {
            gameEndModal.transform.FindChild("ButtonNext").gameObject.SetActive(false);
        }

        /*
        if(this.HasPositiveTerrorRating)
        {
            this.LoadNextLevel();
        }

        this.LoadMainMenu();
         */
    }

    private Player LoadPlayer()
    {
        var information = this.files.ReadFile("Player.json");

        return string.IsNullOrEmpty(information) ? this.NewEmptyPlayer() : this.json.Deserialize(information);
    }

    public void SavePlayer()
    {
        this.player.UpdateLevelStats(this.CurrentLevel, this.villageStats.GoalsAchieved);

        var information = this.json.Serialize(this.player);
        this.files.WriteFile("Player.json", information);
    }

    private Player NewEmptyPlayer()
    {
        return new Player();
    }

    private void LoadNextLevel()
    {
        Application.LoadLevel(this.NextLevel);
    }

    private void LoadMainMenu()
    {
        Application.LoadLevel(0);
    }
}
