using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour, IPooledObject
{
    float cookTime = 0f;

    float rare = 20f, mediumRare = 40f, wellDone = 60f, burnt = 80f;

    public void OnObjectSpawn()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Pan"))
        {
            InvokeRepeating("Cook", 1f, 1f);
        }

        if (other.gameObject.CompareTag("Bun"))
        {
            transform.SetParent(other.gameObject.transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Pan"))
        {
            CancelInvoke("Cook");
        }

        if (other.gameObject.CompareTag("Bun"))
        {
            transform.SetParent(null);
        }
    }

    string Cook()
    {
        cookTime++;

        if(cookTime < rare) { return "Raw"; }

        if(cookTime >= rare && cookTime < mediumRare) { return "Rare"; }

        if(cookTime >= mediumRare && cookTime < wellDone) { return "Medium Rare"; }

        if(cookTime >= wellDone && cookTime < burnt) { return "Well Done"; }

        if(cookTime >= burnt) { return "Burnt"; }

        return "";
    }
}