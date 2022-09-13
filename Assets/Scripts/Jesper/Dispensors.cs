using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dispensors : MonoBehaviour
{
    public GameObject dispensor;
    public GameObject liquidPrefab;
    [SerializeField] ParticleSystem Liquid;

    private void Start()
    {
        Liquid.Stop();
    }
    private void Update()
    {
        Liquid.transform.position = dispensor.transform.position;
        Liquid.transform.rotation = dispensor.transform.rotation;
    }
    public void activateKetchup()
    {
        Liquid.Play();
    }

    public void deactivateKetchup()
    {
        Liquid.Stop();
    }

   
    private void OnParticleCollision(GameObject other)
    {
        // Instantiate(liquidPrefab);
    }
}
