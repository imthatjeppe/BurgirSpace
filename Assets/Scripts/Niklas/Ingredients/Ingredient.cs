using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientManager ingredientManager;

    #region Singleton
    public static Ingredient instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {
        //Physics.IgnoreLayerCollision(0, 11, true);
    }

}
