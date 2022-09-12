using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour, IPooledObject
{
    float cookTime = 0f;

    float rare = 20f, mediumRare = 40f, wellDone = 60f, burnt = 80f;

    bool cooking = false;

    public CookStates states;

    public void OnObjectSpawn()
    {
        GetComponent<MeshCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void FixedUpdate()
    {
        if (!cooking) { return; }

        cookTime++;

        if (cookTime < rare) { states = CookStates.Raw; return; }

        if (cookTime >= rare && cookTime < mediumRare) { states = CookStates.Rare; return; }

        if (cookTime >= mediumRare && cookTime < wellDone) { states = CookStates.mediumRare; return; }

        if (cookTime >= wellDone && cookTime < burnt) { states = CookStates.wellDone; return; }

        if (cookTime >= burnt) { states = CookStates.Burnt; return; }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pan"))
        {
            cooking = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Pan"))
        {
            cooking = false;
        }
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