using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patty : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}