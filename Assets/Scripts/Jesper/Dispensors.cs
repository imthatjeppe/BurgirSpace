using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dispensors : MonoBehaviour
{
    public GameObject dispensor;

    [SerializeField] ParticleSystem ps;


    void Start()
    {
        ps.Stop();
    }
    void Update()
    {
        ps.transform.position = dispensor.transform.position;
        ps.transform.rotation = dispensor.transform.rotation;
    }
    public void activateKetchup()
    {
        ps.Play();
    }

    public void deactivateKetchup()
    {
        ps.Stop();
    }
}
