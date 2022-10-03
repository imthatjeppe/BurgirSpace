using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Setting", menuName = "Setting")]
public class Setting : ScriptableObject
{
    public float GameTime;
    public float minWaitTime;
    public float maxWaitTime;
    public int maxBadOrders;
}
