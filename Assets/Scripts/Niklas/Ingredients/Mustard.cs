using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/Mustard")]
public class Mustard : IngredientManager, IPooledObject
{
    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 4;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
    }

    public void OnObjectSpawn() { }
}