using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Dispensors : MonoBehaviour
{
    public GameObject dispensor;
    public GameObject liquidPrefab;
    public List<ParticleCollisionEvent> collisionEvents;

    [SerializeField] ParticleSystem Liquid;


    private void Start()
    {
        Liquid.Stop();
        collisionEvents = new List<ParticleCollisionEvent>();
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
        Debug.Log("Funkar du?");

        int numCollisionEvents = Liquid.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 1;
        while (i < numCollisionEvents)
        {
            if (!rb) { return; }

            Debug.Log("Hello" + other.name);
            Vector3 point = collisionEvents[i].intersection;
            Instantiate(liquidPrefab, point, Quaternion.identity);
            i++;
        }

    }
}
