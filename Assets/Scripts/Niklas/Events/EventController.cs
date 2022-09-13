using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [HideInInspector] public List<GameEvent> events = new List<GameEvent>();
    [HideInInspector] public GameEvent currentEvent = null;
    [HideInInspector] public int minRandomEventInterval, maxRandomEventInterval;
    [HideInInspector] public bool hasStarted = false;
    int randomEvent = 0;

    void Awake()
    {
        foreach (GameEvent _event in events)
        {
            _event.Init(this);
        }
    }

    void Start()
    {
        if (currentEvent != null) { return; }
        InvokeRepeating("StartRandomEvent", minRandomEventInterval, Random.Range(minRandomEventInterval, maxRandomEventInterval));
    }

    void StartRandomEvent()
    {
        randomEvent = Random.Range(0, events.Count);
        currentEvent = events[randomEvent];
        currentEvent.StartEvent(this);
    }

    void Update()
    {
        currentEvent?.UpdateEvent();
    }

    #region Inspector Functions

    public void AddEvent(GameEvent _event)
    {
        events.Add(_event);
    }

    public void RemoveEvent(int index)
    {
        events.RemoveAt(index);
    }

    public void SwapElements(int index1, int index2)
    {
        GameEvent holder = events[index1];
        events[index1] = events[index2];
        events[index2] = holder;
    }

    #endregion
}