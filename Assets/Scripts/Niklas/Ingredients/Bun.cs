using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bun", menuName = "Object Creator/Item/Food/Bun")]
public class Bun : Food
{
    [SerializeField] GameObject bun;

    void Awake()
    {
        Prefab = bun;
    }
}
