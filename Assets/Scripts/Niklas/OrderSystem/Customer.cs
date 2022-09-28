using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        orderItems = OrderManager.instance.CreateRandomOrder();

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

        ScoreManager.instance.UpdateScore(completion, orderTime, waitTime);

        orderTime = 0;

        waitTime = Random.Range(minWaitTime, maxWaitTime);

        orderItems = OrderManager.instance.CreateRandomOrder();

        GameObject plate = FoodSpawner.instance.SpawnPlate();

        plate.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
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
