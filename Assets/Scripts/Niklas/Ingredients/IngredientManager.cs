using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientManager : ScriptableObject
{
    string ingredientName;
    int id;
    Sprite icon;

    public string IngredientName
    {
        get { return ingredientName; }
        set { ingredientName = value; }
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public Sprite Icon
    {
        get { return icon; }
        set { icon = value; }
    }
}
