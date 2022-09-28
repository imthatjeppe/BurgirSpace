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
    }

    void Update()
    {
        transform.position = target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;
    }

    public void SetOrder()
    {
        for(int i = 0; i < OrderManager.instance.orderItems.Count; i++)
        {
            order.text = order.text + "\n" + OrderManager.instance.orderItems[i].IngredientName;
        }
    }
}
