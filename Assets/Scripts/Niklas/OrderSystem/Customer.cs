using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Customer : MonoBehaviour
{
    List<IngredientManager> orderItems = new List<IngredientManager>();
    List<string> checkOrder = new List<string>();
    [HideInInspector] public float completion = 0;
    float waitTime;
    [SerializeField] float minWaitTime = 120, maxWaitTime = 360;
    float orderTime = 0;
    [SerializeField] GameObject plate;
    [SerializeField] Transform plateSpawnPos;
    CookStates desiredPattyState;
    GameObject patty;

    void Start()
    {
        orderItems = OrderManager.instance.CreateRandomOrder();
        desiredPattyState = OrderManager.instance.GenerateRandomPattyCookState();

        foreach (IngredientManager i in orderItems)
        {
            checkOrder.Add(i.IngredientName);
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    void Update()
    {
        orderTime += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Plate")) { return; }

        if (other.gameObject.transform.GetChild(0) == null) { return; }

        float matches = CompareLists(checkOrder, BurgerManager.instance.BurgerIngredients);

        completion = matches / checkOrder.Count * 100;

        orderTime = 0;

        waitTime = Random.Range(minWaitTime, maxWaitTime);

        foreach (Plate socketObj in FindObjectsOfType<Plate>())
        {
            XRSocketInteractor socket = socketObj.GetComponent<XRSocketInteractor>();

            for(int i = 0; i < socket.interactablesSelected.Count; i++)
            {
                IXRSelectInteractable xr = socket.interactablesSelected[i];

                xr.transform.SetParent(GameObject.FindGameObjectWithTag("FoodHolder").transform);

                if(xr.transform.gameObject.tag == "Patty") { patty = xr.transform.gameObject; }

                xr.transform.gameObject.SetActive(false);
            }
        }

        var iM = patty.GetComponent<Ingredient>().ingredientManager;

        var cook = iM as Cookable;

        ScoreManager.instance.UpdateScore(completion, orderTime, waitTime, desiredPattyState, cook.states);

        AudioManager.instance.PlayOnceLocal("Order complete", gameObject);

        orderItems = OrderManager.instance.CreateRandomOrder();
        desiredPattyState = OrderManager.instance.GenerateRandomPattyCookState();

        FoodSpawner.instance.SpawnPlate();
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
