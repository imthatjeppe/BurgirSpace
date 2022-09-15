using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/Cheese")]
public class Cheese : IngredientManager, IPooledObject
{
    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 8;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
    }

    public void OnObjectSpawn() { }
}