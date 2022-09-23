using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Setting", menuName = "Setting")]
public class Setting : ScriptableObject
{
    public float Time;
    public float score;
    public int failedOrders;
}
