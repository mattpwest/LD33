using UnityEngine;

public class ViewPortEdges : MonoBehaviour
{
    private float right;
    private float left;
    private float top;
    private float bottom;

    public Vector3 Right
    {
        get
        {
            return new Vector3(this.right, 0, 0);
        }
    }

    public Vector3 Top
    {
        get
        {
            return new Vector3(0, this.top, 0);
        }
    }

    public Vector3 Bottom
    {
        get
        {
            return new Vector3(0, this.bottom, 0);
        }
    }

    public Vector3 Left
    {
        get
        {
            return new Vector3(this.left, 0, 0);
        }
    }

    // Use this for initialization
    private void Start()
    {
        var zDist = this.transform.position.z - Camera.main.transform.position.z;

        this.left = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDist)).x;
        this.right = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, zDist)).x;
        this.bottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, zDist)).y;
        this.top = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, zDist)).y;
    }

    // Update is called once per frame
    private void Update() {}
}
