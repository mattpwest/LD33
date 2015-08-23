using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnOnClick : MonoBehaviour
{
    public Transform selectedMonster;
    private Camera cam;
    public Transform goblin;
    public Transform troll;
    private List<BoxCollider2D> spawns;
    private TerrorBank terrorBank;

    // Use this for initialization
    private void Start()
    {
        this.cam = Camera.main;
        this.spawns = GameObject.FindGameObjectsWithTag("Spawn").Select(go => go.GetComponent<BoxCollider2D>()).ToList();
        this.terrorBank = GameObject.Find("Overlord").GetComponent<TerrorBank>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.SpawnOnPosition(Input.mousePosition);
        }
    }

    private void SpawnOnPosition(Vector3 mousePosition)
    {
        var worldPosition = this.cam.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, this.cam.transform.position.z));

        if (this.spawns.Any(s => s.OverlapPoint(worldPosition)))
        {
            int cost = selectedMonster.GetComponent<TerrorCost>().cost;

            if (terrorBank.UseTerror(cost)) {
                Instantiate(selectedMonster, new Vector3(worldPosition.x, worldPosition.y, 0), Quaternion.identity);
            }
        }
    }

    public void SelectGoblin() {
        selectedMonster = goblin;
    }

    public void SelectTroll() {
        selectedMonster = troll;
    }
}
