using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaSound : MonoBehaviour
{

    GameObject spatula;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("NonInteractable"))
        {
            AudioManager.instance.PlayOnceLocal("Spatula", spatula);
        }
    }
}
