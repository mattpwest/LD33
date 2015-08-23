using UnityEngine;

public class Clock : MonoBehaviour
{
    public int TotalSeconds = 120;

    public bool HasTimeRunOut
    {
        get
        {
            return this.TimeLeft < 0;
        }
    }

    public float TimeLeft { get; private set; }

    // Use this for initialization
    private void Start()
    {
        this.TimeLeft = this.TotalSeconds;
    }

    // Update is called once per frame
    private void Update()
    {
        this.TimeLeft -= Time.deltaTime;
    }
}
