using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItem : MonoBehaviour
{
    public bool isFoodInSocket;
    public void IsInSocket()
    {
        isFoodInSocket = !isFoodInSocket;
    }
}
