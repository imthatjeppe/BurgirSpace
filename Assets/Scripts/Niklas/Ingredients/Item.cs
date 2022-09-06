using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{

    GameObject prefab;

    public GameObject Prefab
    {
        get { return prefab; }
        set { prefab = value; }
    }

}
