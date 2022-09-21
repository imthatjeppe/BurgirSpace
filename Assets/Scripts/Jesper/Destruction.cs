using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NonInteractable"))
        {
            foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
                foreach (Collider cl in GetComponentsInChildren<Collider>())
                {
                    cl.enabled = true;

                    Destroy(gameObject, 3f);
                }
            }
                
        }
    }
}
