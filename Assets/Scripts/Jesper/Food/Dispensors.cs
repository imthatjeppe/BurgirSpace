using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dispensors : MonoBehaviour
{
    public GameObject dispensor;
    [SerializeField] ParticleSystem ps;
    void Awake()
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
        AudioManager.instance.PlayOnceLocal("Squirt", gameObject);
    }

    public void deactivateKetchup()
    {
        ps.Stop();
    }
}
