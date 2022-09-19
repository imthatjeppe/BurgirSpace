using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    List<IngredientManager> orderItems = new List<IngredientManager>();
    List<string> checkOrder = new List<string>();
    [HideInInspector] public float completion = 0;

    void Start()
    {
        orderItems = OrderManager.instance.CreateRandomOrder();

        foreach (IngredientManager i in orderItems)
        {
            checkOrder.Add(i.IngredientName);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plate")) { return; }

        if (other.gameObject.transform.GetChild(0) == null) { return; }

        float matches = CompareLists(checkOrder, BurgerManager.instance.BurgerIngredients);

        completion = matches / checkOrder.Count * 100;

        Debug.Log("Burger completion percentage: " + completion);

        orderItems = OrderManager.instance.CreateRandomOrder();
    }

    static float CompareLists(List<string> required, List<string> check)
    {
        float matches = 0;

        for (int i = 0; i < check.Count; i++)
        {
            if (required.Exists(e => e.EndsWith(check[i])))
            {
                matches++;
            }
        }
        return matches;
    }

}
