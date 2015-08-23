using UnityEngine;
using System.Collections;

public class CrossfadeMusic : MonoBehaviour {

    AudioSource villageMusic;
    AudioSource warMusic;

	void Start () {
        villageMusic = GameObject.Find("VillageMusic").GetComponent<AudioSource>();
        warMusic = GameObject.Find("WarMusic").GetComponent<AudioSource>();

        villageMusic.volume = 1.0f;
        warMusic.volume = 0.0f;
	}
	
	void Update () {
        if (GameObject.FindGameObjectsWithTag("Monster").Length > 0) {
            FadeOut(villageMusic, 0.3f);
            FadeIn(warMusic, 1.0f);
        } else {
            FadeOut(warMusic, 0.0f);
            FadeIn(villageMusic, 1.0f);
        }

        Debug.Log("VOLUMES - village: " + villageMusic.volume + "; war: " + warMusic.volume);
	}

    void FadeIn(AudioSource src, float level) {
        if (src.volume < level) {
            float change = (level - src.volume) / 100.0f;
            src.volume = src.volume + change;
        }
    }

    void FadeOut(AudioSource src, float level) {
        if (src.volume > level) {
            float change = (src.volume - level) / 100.0f;
            src.volume = src.volume - change;
        }
    }
}
