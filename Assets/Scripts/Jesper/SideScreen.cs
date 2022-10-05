using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideScreen : MonoBehaviour
{
    public TMP_Text order;

    public void SetOrder()
    {
        for(int i = 0; i < OrderManager.instance.orderItems.Count; i++)
        {
            order.text = order.text + "\n" + OrderManager.instance.orderItems[i].IngredientName;
        }
    }
}
