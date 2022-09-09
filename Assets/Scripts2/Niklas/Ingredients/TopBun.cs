using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBun : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        GetComponent<BoxCollider>().isTrigger = false;
        GetComponent<Rigidbody>().useGravity = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            var joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = other.rigidbody;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
        }
    }
}