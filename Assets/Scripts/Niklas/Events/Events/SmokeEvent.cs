using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeEvent : GameEvent
{
    float timer = 0;
    public float maxTime = 0;
    [SerializeField] int minEventRestartTime, maxEventRestartTime;

    public override void Init(EventController ec)
    {
        ec.minRandomEventInterval = minEventRestartTime + (int)maxTime;
        ec.maxRandomEventInterval = maxEventRestartTime + (int)maxTime;
    }

    public override void StartEvent(EventController ec)
    {
        this.ec = ec;
    }

    public override void UpdateEvent()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            CompletedEvent();

            ec.currentEvent = null;
        }
    }

    public override void CompletedEvent()
    {
        timer = 0;
    }

    public override string ToString()
    {
        if (eventName == "") { return "(SmokeEvent)"; }
        return $"{eventName} (SmokeEvent)";
    }
}