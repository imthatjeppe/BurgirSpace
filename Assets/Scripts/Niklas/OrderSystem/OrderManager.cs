using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderManager : MonoBehaviour
{
    public List<IngredientManager> ingredients = new();
    [SerializeField] IngredientManager TopBun, Patty, BottomBun;
    public List<IngredientManager> orderItems = new();
    public Order orderPrefab;
    public GameObject orderListEntryPrefab;

    public void InstantiateOrder()
    {
        var chosenIngredients = CreateRandomOrder();    
        var order = Instantiate(orderPrefab, this.transform.position, this.transform.rotation);
    
        foreach(IngredientManager i in chosenIngredients)
        {
            var orderListEntry = Instantiate(orderListEntryPrefab, order.orderList.transform);
            orderListEntry.GetComponentInChildren<TextMeshProUGUI>().text = (i.IngredientName);
            orderListEntry.GetComponentInChildren<Image>().sprite = i.Icon;
            Debug.Log(i.IngredientName);
        }     
    }
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
