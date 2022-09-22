using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodSnap : MonoBehaviour
{
    public Vector3 offset;
    Rigidbody rb;
    Transform foodParents;
    [SerializeField] Transform stackPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FoodHolder"))
        {
            Transform othertransform = other.transform.parent;

            Rigidbody otherRB = othertransform.GetComponent<Rigidbody>();
            otherRB.isKinematic = true;
            other.enabled = false;

            if(foodParents == null)
            {
                foodParents = othertransform;
                foodParents.position = stackPosition.position;
                foodParents.parent = stackPosition;
            }
            else
            {
                foodParents.position += Vector3.up * (othertransform.localScale.y);
                othertransform.position = stackPosition.position;
                othertransform.parent = stackPosition;
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        rb.freezeRotation = false;
    }
}
