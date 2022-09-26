using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCompleted : MonoBehaviour
{
    public OrderManager orderManager;
    public GameObject FoodSpawner;

    private void Start()
    {
        orderManager.GetComponent<OrderManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Patty" || gameObject.tag == ("Bun"))
        {
            Debug.Log("Burger in zone");
            orderManager.InstantiateOrder();
            AudioManager.instance.PlayOnceLocal("Food spawn", FoodSpawner);
        }
    }
}
