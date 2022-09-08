using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dispensors : MonoBehaviour
{
    public GameObject dispensor;
    [SerializeField] VisualEffect Liquid;

    private void Start()
    {
        Liquid.enabled = false;
    }

    private void Update()
    {
        Liquid.transform.position = dispensor.transform.position;
        Liquid.transform.rotation = dispensor.transform.rotation;
    }
    public void activateKetchup()
    {
        Liquid.Play();
        Liquid.enabled = true;
    }

    public void deactivateKetchup()
    {
        Liquid.Stop();
        Liquid.enabled = false;
    }
    
}
