using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : IngredientManager, IPooledObject
{
    [HideInInspector] public CookStates states;

    public CookStates States
    {
        get { return states; }
        set { states = value; }
    }

    public void OnObjectSpawn() { }

}

public enum CookStates
{
    Raw,
    Rare,
    mediumRare,
    wellDone,
    Burnt
}