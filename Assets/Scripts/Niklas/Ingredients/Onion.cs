using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/Onion")]
public class Onion : IngredientManager, IPooledObject
{
    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 5;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
    }

    public void OnObjectSpawn() { }
}