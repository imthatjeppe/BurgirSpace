using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class applyKetchup : MonoBehaviour
{
    public GameObject ketchup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hellooo");

        if (other.CompareTag("NonInteractable"))
        {
            Instantiate(ketchup);
        }
    }
}
