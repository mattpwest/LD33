using System;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public GameObject LeftSpawn;
    public GameObject RightSpawn;
    public GameObject TopSpawn;
    public GameObject BottomSpawn;
    public float SpawnSize = 2.0f;

    private float SideSpawnHeight
    {
        get
        {
            return this.TopSpawn.transform.position.y - this.BottomSpawn.transform.position.y - (this.SpawnSize * 2);
        }
    }

    private float TopBottomSpawnWidth
    {
        get
        {
            return this.RightSpawn.transform.position.x - this.LeftSpawn.transform.position.x;
        }
    }

    // Use this for initialization
    private void Update()
    {
        var viewPortEdges = Camera.main.GetComponent<ViewPortEdges>();

        this.SetupSideSpawn(this.LeftSpawn, viewPortEdges.Left);
        this.SetupSideSpawn(this.RightSpawn, viewPortEdges.Right);
        this.SetupTopBottomSpawn(this.TopSpawn, viewPortEdges.Top);
        this.SetupTopBottomSpawn(this.BottomSpawn, viewPortEdges.Bottom);
    }

    private void SetupSideSpawn(GameObject sideSpawn, Vector3 spawnPosition)
    {
        sideSpawn.transform.position = spawnPosition;

        var spawnOffsetX = spawnPosition.x / -Math.Abs(spawnPosition.x) * this.SpawnSize;

        sideSpawn.GetComponent<BoxCollider2D>().offset = new Vector2(spawnOffsetX / 2, 0);
        sideSpawn.GetComponent<BoxCollider2D>().size = new Vector2(this.SpawnSize, this.SideSpawnHeight);
    }

    private void SetupTopBottomSpawn(GameObject topBottomSpawn, Vector3 spawnPosition)
    {
        topBottomSpawn.transform.position = spawnPosition;

        var spawnOffsetY = spawnPosition.y / -Math.Abs(spawnPosition.y) * this.SpawnSize;

        topBottomSpawn.GetComponent<BoxCollider2D>().offset = new Vector2(0, spawnOffsetY / 2);
        topBottomSpawn.GetComponent<BoxCollider2D>().size = new Vector2(this.TopBottomSpawnWidth, this.SpawnSize);
    }
}
