using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideScreen : MonoBehaviour
{
    public TMP_Text order1;
    public TMP_Text pattyState;

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

    public void SetOrder(List<IngredientManager> orderItems)
    {
        string temp1 = "";

        foreach (IngredientManager im0 in orderItems)
        {
            temp1 = temp1 + "\n" + im0.IngredientName;
            order1.text = temp1;
            pattyState.text = OrderManager.instance.desiredState.ToString();
        }

    }
}
