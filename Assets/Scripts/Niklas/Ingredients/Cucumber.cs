using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/Cucumber")]
public class Cucumber : IngredientManager, IPooledObject
{
    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 7;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
    }

    public void OnObjectSpawn() { }
}