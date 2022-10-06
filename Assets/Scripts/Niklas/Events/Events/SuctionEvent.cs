using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuctionEvent : GameEvent
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public Vector3 dir;
    float timer = 0;
    public float maxTime = 0;
    [SerializeField] int minEventRestartTime, maxEventRestartTime;

    public override void Init(EventController ec)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ec.minRandomEventInterval = minEventRestartTime + (int)maxTime;
        ec.maxRandomEventInterval = maxEventRestartTime + (int)maxTime;
    }

    public override void StartEvent(EventController ec)
    {
        this.ec = ec;

        dir = new Vector3(Random.value, Random.value, Random.value);

        Debug.Log("Starting Suction Event");
    }

    public override void UpdateEvent()
    {
        timer += Time.deltaTime;
        Debug.Log("sucking: " + dir);
        player.transform.Translate(dir * Time.deltaTime * 0.3f);

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
        if (eventName == "") { return "(SuctionEvent)"; }
        return $"{eventName} (SuctionEvent)";
    }
}