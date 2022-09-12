using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBun : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        GetComponent<MeshCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }
}