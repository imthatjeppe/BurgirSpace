using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideScreen : MonoBehaviour
{
    public TMP_Text order1;
    public TMP_Text order2;
    public TMP_Text order3;

    bool isset1 = false, isset2 = false, isset3 = false;

    public List<List<IngredientManager>> customerOrders = new List<List<IngredientManager>>();

    #region Singleton
    public static SideScreen instance;
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

    public void SetOrder()
    {
        string temp1 = "";
        string temp2 = "";
        string temp3 = "";


        if (isset1 == false)
        {
            foreach (IngredientManager im0 in customerOrders[0])
            {
                Debug.Log("order1" + im0.IngredientName);
                temp1 = temp1 + "\n" + im0.IngredientName;
                order1.text = temp1;
            }
            isset1 = true;
        }

        if (customerOrders.Count < 2) { return; }

        if (isset2 == false)
        {
            foreach (IngredientManager im1 in customerOrders[1])
            {
                Debug.Log("order2" + im1.IngredientName);
                temp2 = temp2 + "\n" + im1.IngredientName;
                order2.text = temp2;
            }
            isset2 = true;
        }

        if (customerOrders.Count < 3) { return; }


        if (isset3 == false)
        {
            foreach (IngredientManager im2 in customerOrders[2])
            {
                Debug.Log("order3" + im2.IngredientName);
                temp3 = temp3 + "\n" + im2.IngredientName;
                order3.text = temp3;
            }
            isset3 = true;
        }

        isset1 = isset2 = isset3 = false;

    }
}
