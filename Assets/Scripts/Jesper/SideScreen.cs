using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideScreen : MonoBehaviour
{
    public TMP_Text order1;
    public TMP_Text order2;
    public TMP_Text order3;

    [SerializeField] public List<List<IngredientManager>> customerOrders = new List<List<IngredientManager>>();

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

    void OnEnable()
    {
        SetOrder();
    }

    public void SetOrder()
    {

        foreach(IngredientManager i0 in customerOrders[0])
        {
            order1.text = order1.text + "\n" + i0.IngredientName;
        }

        foreach (IngredientManager i1 in customerOrders[1])
        {
            order2.text = order2.text + "\n" + i1.IngredientName;
        }

        foreach (IngredientManager i2 in customerOrders[2])
        {
            order3.text = order3.text + "\n" + i2.IngredientName;
        }
    }
}
