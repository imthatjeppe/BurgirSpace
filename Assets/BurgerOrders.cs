using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class BurgerOrders : MonoBehaviour
{ 
    public List<string> Ingredients = new List<string>();
    public List<string> Burgers = new List<string>();
    public float counter;
    public Order orderPrefab;
    public GameObject recipeListItemPrefab;
    public GameObject orderList;
    public int minRandomIngredients = 2;
    public int maxRandomIngredients = 5;
    System.Action[] functions;

    private void Awake()
    {
        functions = new System.Action[] { GenerateCustomOrder, GenerateMenuOrder };
    }
    void RandomOrder()
    {
        functions[Random.Range(0, functions.Length)]();
    }
    private void Start()
    {
        Ingredients.Add("Tomato");
        Ingredients.Add("Cheese");
        Ingredients.Add("Cucumber");
        Ingredients.Add("Onion");
        Ingredients.Add("Ketchup");
        Ingredients.Add("Mustard");
        counter = 0;
        Burgers.Add("Big Kahuna");
        Burgers.Add("Cheese Royale");
        Burgers.Add("Star-Spangled Burger");
        Burgers.Add("Borgir Deluxe");
        
    }

    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= 1)
        {
            RandomOrder();
            counter = 0;
        }
    }

    private void GenerateCustomOrder()
    {
        var order = Instantiate(orderPrefab, this.transform.position, this.transform.rotation);
        order.transform.Rotate(Vector3.right, 90f);
        var recipeListItemInstance = Instantiate(recipeListItemPrefab, order.orderList.transform);
        recipeListItemInstance.GetComponent<TextMeshProUGUI>().text = "Buns";        
        recipeListItemInstance = Instantiate(recipeListItemPrefab, order.orderList.transform);
        recipeListItemInstance.GetComponent<TextMeshProUGUI>().text = "Patty";
        var numberOfIngredients = Random.Range(minRandomIngredients, maxRandomIngredients);
        var listOfChosenIngredients = new List<int>();
        
        for (int i = 0; i <= numberOfIngredients; i++)
        {
            var ingredientIndex = Random.Range(0, Ingredients.Count);

            while (listOfChosenIngredients.Contains(ingredientIndex))
            {
                ingredientIndex = Random.Range(0, Ingredients.Count);
            }
            string chooseIngredients = Ingredients[ingredientIndex];
            recipeListItemInstance = Instantiate(recipeListItemPrefab, order.orderList.transform);
            recipeListItemInstance.GetComponent<TextMeshProUGUI>().text = chooseIngredients;
            listOfChosenIngredients.Add(ingredientIndex);
        }
    }
    private void GenerateMenuOrder()
    {
        //Generate an order, much like the one from GenerateCustomOrder(), but this will be a preset burger with an in game recipe.
        //Use an array to choose a random function between the two whenever a new order is to be placed.
        var order = Instantiate(orderPrefab, this.transform.position, this.transform.rotation);
        order.transform.Rotate(Vector3.right, 90f);
        var menuBurgerListItemInstance = Instantiate(recipeListItemPrefab, order.orderList.transform);
        var burgerIndex = Random.Range(0, Burgers.Count);
        string chooseMenuBurger = Burgers[burgerIndex];
        menuBurgerListItemInstance.GetComponent<TextMeshProUGUI>().text = chooseMenuBurger;
    }
}
