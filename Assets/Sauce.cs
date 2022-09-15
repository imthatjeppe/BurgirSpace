using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    ParticleSystem part;
    List<ParticleCollisionEvent> collisionEvents;
    [SerializeField] GameObject liquidPrefab;

    GameObject SauceHolder;

    void Start()
    {
        SauceHolder = new GameObject("SauceHolder");
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        Physics.IgnoreLayerCollision(0, 9, true);
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();

        int i = 0;
        
        if(numCollisionEvents == 0) { return; }

        //if (!rb.CompareTag("Patty")) { return; }

        while (i < numCollisionEvents)
        {
            Vector3 pos = collisionEvents[i].intersection;
            GameObject Sauce = Instantiate(liquidPrefab, pos, Quaternion.identity);
            Sauce.transform.SetParent(SauceHolder.transform);
            i++;
            Destroy(Sauce, 2f);
        }

    }
}
