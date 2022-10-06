using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class Customer : MonoBehaviour
{
    List<IngredientManager> orderItems = new List<IngredientManager>();
    List<string> checkOrder = new List<string>();
    [HideInInspector] public float completion = 0;
    float waitTime;
    float minWaitTime, maxWaitTime;
    float orderTime = 0;
    [SerializeField] TMP_Text orderTimeTMP, waitTimeTMP;
    [SerializeField] Transform plateSpawnPos;
    CookStates desiredPattyState;
    GameObject patty, plate;
    bool fadeOut = false;
    bool updatingScore = false;
    List<bool> condiment = new List<bool>();

    void Start()
    {
        MakeOrder();
    }

    void Update()
    {
        if (fadeOut)
        {
            Color color = plate.GetComponent<Renderer>().material.color;

            float fadeAmount = color.a - (2f * Time.deltaTime);

            color = new Color(color.r, color.g, color.b, fadeAmount);
            plate.GetComponent<MeshRenderer>().material.color = color;

            foreach (Transform child in plate.transform.GetChild(0))
            {
                Color colorChild = child.GetComponent<Renderer>().material.color;

                float fadeAmountChild = color.a - (2f * Time.deltaTime);

                color = new Color(color.r, color.g, color.b, fadeAmountChild);

                child.GetComponent<MeshRenderer>().material.color = colorChild;
            }

            if (color.a <= 0)
            {
                fadeOut = false;
            }
        }

        if (orderTime >= waitTime)
        {
            MakeOrder();
            ScoreManager.instance.badOrder++;
            Stats.instance.badOrders.text = "Bad Orders: " + ScoreManager.instance.badOrder;
            return;
        }

        orderTime += Time.deltaTime;
        orderTimeTMP.text = "Order Time: " + orderTime.ToString("f0");
    }

    void MakeOrder()
    {
        orderTime = 0;

        minWaitTime = GameManager.instance.difficultySetting.minWaitTime;
        maxWaitTime = GameManager.instance.difficultySetting.maxWaitTime;

        orderItems = OrderManager.instance.CreateRandomOrder();
        desiredPattyState = OrderManager.instance.GenerateRandomPattyCookState();
        condiment = OrderManager.instance.Condiment();

        foreach (IngredientManager i in orderItems)
        {
            checkOrder.Add(i.IngredientName);
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }

        waitTimeTMP.text = "Wait Time: " + waitTime.ToString("f0");
        SideScreen.instance.SetOrder(orderItems);
    }

    void OnTriggerEnter(Collider other)
    {
        bool mustard = false, ketchup = false;
        if (other.gameObject.CompareTag("Mustard")) { mustard = true; }
        if (other.gameObject.CompareTag("Ketchup")) { ketchup = true; }

        if (updatingScore) { return; }
        if (!other.CompareTag("Plate")) { return; }

        if (other.gameObject.transform.GetChild(0) == null) { return; }

        float bonus = 0f;

        if (condiment[0] == mustard) { bonus += 20; }
        if (condiment[1] == ketchup) { bonus += 20; }

        foreach (Plate socketObj in FindObjectsOfType<Plate>())
        {
            XRSocketInteractor socket = socketObj.GetComponent<XRSocketInteractor>();

            for (int i = 0; i < socket.interactablesSelected.Count; i++)
            {
                IXRSelectInteractable xr = socket.interactablesSelected[i];

                xr.transform.SetParent(GameObject.FindGameObjectWithTag("FoodHolder").transform);

                if (xr.transform.gameObject.tag == "Patty") { patty = xr.transform.gameObject; }

                xr.transform.gameObject.SetActive(false);
            }
        }

        if (patty == null) { return; }

        float matches = CompareLists(checkOrder, BurgerManager.instance.BurgerIngredients);

        completion = matches / checkOrder.Count * 100;

        if (waitTime > orderTime)
        {
            GameManager.instance.difficultySetting.GameTime += waitTime - orderTime;
        }

        orderTime = 0;

        waitTime = Random.Range(minWaitTime, maxWaitTime);

        if (patty != null)
        {
            var iM = patty.GetComponent<Ingredient>().ingredientManager;

            var cook = iM as Cookable;

            ScoreManager.instance.UpdateScore(completion, orderTime, waitTime, desiredPattyState, cook.states, bonus);
        }
        else
        {
            ScoreManager.instance.UpdateScore(completion, orderTime, waitTime, desiredPattyState, CookStates.Raw, bonus);
        }

        plate = other.gameObject;

        StartCoroutine(NewOrder());
    }

    IEnumerator NewOrder()
    {
        fadeOut = true;
        updatingScore = true;

        plate.GetComponent<XRGrabInteractable>().enabled = false;
        plate.GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSeconds(2.1f);

        plate.GetComponent<MeshRenderer>().material.color = new Color(plate.GetComponent<MeshRenderer>().material.color.r, plate.GetComponent<MeshRenderer>().material.color.g, plate.GetComponent<MeshRenderer>().material.color.b, 1);

        plate.GetComponent<XRGrabInteractable>().enabled = true;
        plate.GetComponent<Rigidbody>().isKinematic = false;

        orderItems = OrderManager.instance.CreateRandomOrder();
        desiredPattyState = OrderManager.instance.GenerateRandomPattyCookState();
        condiment = OrderManager.instance.Condiment();

        plate = null;
        patty = null;

        updatingScore = false;
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
