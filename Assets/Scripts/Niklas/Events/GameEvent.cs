using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class GameEvent : ScriptableObject
{
    [SerializeField]
    public string eventName;

    [HideInInspector]
    public bool Minimized = true;

    protected EventController ec;

    public virtual void Init(EventController ec) { }
    public abstract void StartEvent(EventController ec);
    public virtual void UpdateEvent() { }
    public abstract void CompletedEvent();
}