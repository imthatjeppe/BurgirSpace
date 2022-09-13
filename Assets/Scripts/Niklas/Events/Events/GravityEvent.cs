using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEvent : GameEvent
{
    [HideInInspector] public List<Rigidbody> objects;
    float timer = 0;
    public float maxTime = 0;

    public override void Init() { }

    public override void StartEvent(EventController ec)
    {
        foreach (Rigidbody obj in FindObjectsOfType<Rigidbody>())
        {
            if (obj.gameObject.tag != "Button")
                objects.Add(obj);
        }

        this.ec = ec;

        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = false;
            obj.velocity = Vector3.up;
        }
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
        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = true;
        }
        timer = 0;
    }

    public override string ToString()
    {
        if (eventName == "") { return "(GravityEvent)"; }
        return $"{eventName} (GravityEvent)";
    }
}