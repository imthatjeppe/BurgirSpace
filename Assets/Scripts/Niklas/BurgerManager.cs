using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerManager : MonoBehaviour
{
    [HideInInspector] public List<string> BurgerIngredients = new List<string>();

    #region Singleton
    public static BurgerManager instance;
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

    public void AddIngredients(string name)
    {
        BurgerIngredients.Add(name);
    }

    public void RemoveIngredients(string name)
    {
        BurgerIngredients.Remove(name);
    }
}
