using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideScreen : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public TMP_Text order;
    public GameObject display;
    // Start is called before the first frame update

    void Start()
    {
        display.transform.position = transform.position;
        display.transform.rotation = transform.rotation;

        //transform.eulerAngles = new Vector3(0, 0, target.eulerAngles.z + 45);
    }

    public void SetOrder()
    {
        for(int i = 0; i < OrderManager.instance.orderItems.Count; i++)
        {
            order.text = order.text + "\n" + OrderManager.instance.orderItems[i].IngredientName;
        }
    }
}
