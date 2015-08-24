using UnityEngine;

public class Clock : MonoBehaviour
{
    bool stopped = true;
    public int TotalSeconds = 120;

    public bool HasTimeRunOut
    {
        get
        {
            return this.TimeLeft < 0;
        }
    }

    public bool IsStopped {
        get
        {
            return this.stopped;
        }
    }

    public void StopClock() {
        this.stopped = true;
    }

    public void StartClock() {
        this.stopped = false;
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
        if (stopped) {
            return;
        }

        this.TimeLeft -= Time.deltaTime;
    }
}
