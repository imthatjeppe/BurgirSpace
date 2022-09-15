using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public List<IngredientManager> ingredients = new List<IngredientManager>();
    [SerializeField] IngredientManager TopBun, Patty, BottomBun;
    public List<IngredientManager> orderItems = new List<IngredientManager>();

    public List<IngredientManager> CreateRandomOrder()
    {
        orderItems.Clear();

        int numOfIngredients = Random.Range(0, ingredients.Count);

        for (int i = 0; i < numOfIngredients; i++)
        {
            orderItems.Add(ingredients[i]);
        }

        orderItems.Insert(0, TopBun);
        orderItems.Insert(Mathf.RoundToInt((numOfIngredients + 2) / 2), Patty);
        orderItems.Insert(numOfIngredients + 2, BottomBun);

        return orderItems;
    }

}
