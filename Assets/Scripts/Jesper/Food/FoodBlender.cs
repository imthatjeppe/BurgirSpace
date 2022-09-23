using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBlender : MonoBehaviour
{
    public GameObject spawnTube;
    public GameObject addFoodTube;

    public List<GameObject> foodItems;

    private FoodID foodID;
    private Vector3 offset = new Vector3(0.15f, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            var foodID = other.GetComponent<FoodID>();
            //foodID = FindObjectOfType<FoodID>();

            Destroy(other.gameObject);

            for (int i = 0; i < foodID.amountItems; i++)
            {
                Instantiate(foodItems[foodID.foodID], spawnTube.transform.position + offset, Quaternion.identity);
            }
        }
    }
}
