using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float duration = 0;
    float elapsedTime = 0;
    bool started = false;
    bool running = false;

    public bool isFinished
    {
        get { return started && !running; }
    }

    public bool isRunning
    {
        get { return running; }
    }

    public float Duration
    {
        set
        {
            if(!running)
            {
                duration = value;
            }
        }
    }

    public void Run()
    {
        if(duration > 0)
        {
            started = true;
            running = true;
            elapsedTime = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= duration)
        {
            running = false;
            elapsedTime = 0;
        }
    }
}
