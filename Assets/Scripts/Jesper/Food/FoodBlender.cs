using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBlender : MonoBehaviour
{
    public GameObject spawnTube;
    public GameObject addFoodTube;
    public List<GameObject> foodItems;
    FoodID foodID;

    public Vector3 offset = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            foodID = other.GetComponent<FoodID>();
            Destroy(other.gameObject);
            AudioManager.instance.PlayOnceLocal("Food mixer", gameObject);
            transform.parent.gameObject.GetComponent<Animator>().SetTrigger("Shake");

            Invoke("MixVegetable", 1f);
        }
    }

    void MixVegetable()
    {
        for (int i = 0; i < foodID.amountItems; i++)
        {
            GameObject obj = Instantiate(foodItems[foodID.foodID], spawnTube.transform.position, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(offset, ForceMode.Impulse);
        }
    }
}
