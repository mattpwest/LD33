using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SpawnOnClick : MonoBehaviour
{
    public Transform initialSelectedMonster;
    private Transform selectedMonster;
    private Camera cam;
    public float spawnDelaySeconds = 1.0f;
    private List<BoxCollider2D> spawns;
    private TerrorBank terrorBank;
    private float spawnEnergy = 1.0f;
    private Button[] buttons;
    private Vector3 spawnLocation = new Vector3(0, 0, 0);
    private int spawnFrameDelay = -1;
    private Clock clock;

    private void Start()
    {
        SelectMonster(initialSelectedMonster);
        this.cam = Camera.main;
        this.spawns = GameObject.FindGameObjectsWithTag("Spawn").Select(go => go.GetComponent<BoxCollider2D>()).ToList();
        this.terrorBank = GameObject.Find("TerrorBank").GetComponent<TerrorBank>();
        buttons = GameObject.FindObjectsOfType<UnityEngine.UI.Button>();
        clock = GameObject.FindObjectOfType<Clock>();
    }

    private void Update()
    {
        if (clock.IsStopped) {
            return;
        }

        spawnFrameDelay--;
        spawnEnergy += Time.deltaTime;

        if (spawnEnergy >= spawnDelaySeconds) {
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].interactable = true;
            }
        } else {
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].interactable = false;
            }
        }

        // Hack to delay spawning by a frame so that a monster select click can cancel the spawn
        Spawn();

        if(Input.GetMouseButtonDown(0) && spawnEnergy >= spawnDelaySeconds)
        {
            this.SpawnOnPosition(Input.mousePosition);
        }
    }

    private void SpawnOnPosition(Vector3 mousePosition)
    {
        var worldPosition = this.cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, this.cam.transform.position.z));

        if (this.spawns.Any(s => s.OverlapPoint(worldPosition)))
        {
            spawnLocation = new Vector3(worldPosition.x, worldPosition.y, 0);
            spawnFrameDelay = 10;
        }
    }

    private void Spawn() {
        if (spawnFrameDelay != 0) {
            return;
        }

        int cost = selectedMonster.GetComponent<TerrorCost>().cost;
        if (terrorBank.UseTerror(cost)) {
            spawnEnergy = 0.0f;
            Instantiate(selectedMonster, spawnLocation, Quaternion.identity);
        }
    }

    public void SelectMonster(Transform monster) {
        spawnFrameDelay = -1;
        selectedMonster = monster;
    }
}
