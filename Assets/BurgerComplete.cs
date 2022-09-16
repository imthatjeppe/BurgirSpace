using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerComplete : MonoBehaviour
{
    public BurgerOrders burgerOrders;

    private void Start()
    {
        burgerOrders.GetComponent<BurgerOrders>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Patty" || gameObject.tag == ("Bun"))
        {
            Debug.Log("Burger in zone");
            burgerOrders.RandomOrder();
        }
    }
}
