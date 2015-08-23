using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateGoalsAchieved : MonoBehaviour {

    public int thisGoal = 1;
    public Sprite unachieved;
    public Sprite achieved;
    VillageStats villageStats;
    Image image;

	void Start () {
        villageStats = FindObjectOfType<VillageStats>();
        image = GetComponent<Image>();
        image.sprite = unachieved;
	}
	
	void Update () {
        if (villageStats.GoalsAchieved >= thisGoal && image.sprite != achieved) {
            image.sprite = achieved;
        }
	}
}
