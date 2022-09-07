using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public Transform target;
    //public Renderer noPhysicalHand;
    //public float showNonPhysicalDistance = 0.05f;

    private Rigidbody rb;
    private Collider[] handColliders;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        handColliders = GetComponentsInChildren<Collider>();
        Physics.IgnoreLayerCollision(6, 7, true);
        Physics.IgnoreLayerCollision(6, 8, true);
    }

    private void Update()
    {
        //float distance = Vector3.Distance(transform.position, target.position);

        //if (distance > showNonPhysicalDistance)
        //{
        //    noPhysicalHand.enabled = true;
        //}
        //else
        //    noPhysicalHand.enabled = false;
    }

    public void EnableHandColliders()
    {
        foreach (var item in handColliders)
        {
            item.enabled = true;
        }
    }
    public void DisableHandColliders()
    {
        foreach (var item in handColliders)
        {
            item.enabled = false;
        }
    }

    public void EnableHandCollidersDelay(float delay)
    {
        Invoke("EnableHandColliders", delay);
    }
    private void FixedUpdate()
    {
        //Position
        rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        //Rotation
        Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceInDegree = angleInDegree * rotationAxis;

        rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
