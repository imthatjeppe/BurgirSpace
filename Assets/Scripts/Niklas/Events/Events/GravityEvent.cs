using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEvent : GameEvent
{
    [HideInInspector]public List<Rigidbody> objects;
    float timer = 0;
    public float maxTime = 0;

    public override void Init()
    {
        foreach (Rigidbody obj in FindObjectsOfType<Rigidbody>())
        {
            if (obj.gameObject.tag != "Button")
                objects.Add(obj);
        }
    }

    public override void StartEvent(EventController ec)
    {
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
            CompletedEvent();
    }

    public override void CompletedEvent()
    {
        foreach (Rigidbody obj in objects)
        {
            obj.useGravity = true;
        }
        ec.NextEvent();
    }

    public override string ToString()
    {
        if (eventName == "") { return "(GravityEvent)"; }
        return $"{eventName} (GravityEvent)";
    }
}