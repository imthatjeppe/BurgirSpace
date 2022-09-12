using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CookState : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum CookStates
{
    Raw,
    Rare,
    mediumRare,
    wellDone,
    Burnt
}
