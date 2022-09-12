using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [HideInInspector] public List<GameEvent> events = new List<GameEvent>();
    GameEvent currentEvent = null;

    bool hasStarted = false;

    void Start()
    {
        foreach (GameEvent _event in events)
        {
            _event.Init();
        }

        InvokeRepeating("PlayEvent", 15f, 20f);
    }

    public void NextEvent()
    {
        if (events.Count == 0)
        {
            Debug.Log("Event Over");
            //play complete event audio and haptics
            //Destroy(gameObject);
            return;
        }
        else
        {
            Debug.Log("Event Started");
            //play start event audio and haptics
            currentEvent = events[0];
            currentEvent.StartEvent(this);
            //events.RemoveAt(0);

            if (!hasStarted)
            {
                hasStarted = true;
            }
        }
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

    public void PlayEvent()
    {
        if (currentEvent != null) { return; }

        NextEvent();
    }
}