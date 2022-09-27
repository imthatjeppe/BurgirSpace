using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    void Awake()
    {
        Physics.IgnoreLayerCollision(10, layer, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
