using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerComplete : MonoBehaviour
{
    public OrderManager orderManager;

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
        }
    }
}
