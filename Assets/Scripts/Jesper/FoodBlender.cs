using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBlender : MonoBehaviour
{
    public GameObject spawnTube;
    public GameObject addFoodTube;

    public List<GameObject> foodItems;

    private FoodID foodID;
    private Vector3 offset = new Vector3(0, 0, 0.5f);

    void Start()
    {
        foodID = FindObjectOfType<FoodID>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Debug.Log("I am in the Blender");
            Instantiate(foodItems[foodID.foodID], spawnTube.transform.position + offset, Quaternion.identity);
        }
    }
}
