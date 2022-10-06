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
    public OrderEntry orderListEntryPrefab;
    public CookStates desiredState;

    #region Singleton
    public static OrderManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

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

    public CookStates GenerateRandomPattyCookState()
    {
        int random = Random.Range(1, 3);

        CookStates desiredPattyState = new CookStates();

        if (random == 1) { desiredPattyState = CookStates.Rare; }
        if (random == 2) { desiredPattyState = CookStates.mediumRare; }
        if (random == 3) { desiredPattyState = CookStates.wellDone; }

        desiredState = desiredPattyState;

        return desiredPattyState;
    }

    public List<bool> Condiment()
    {
        bool mustard = false, ketchup = false;
        List<bool> condiment = new List<bool>();


        float roll = Random.Range(1, 4);


        if (roll == 1) { mustard = true; ketchup = false; }
        if (roll == 2) { ketchup = true; mustard = false; }
        if (roll == 3) { ketchup = false; mustard = false; }
        if (roll == 4) { ketchup = true; mustard = true; }

        condiment.Add(mustard);
        condiment.Add(ketchup);

        return condiment;
    }
}
