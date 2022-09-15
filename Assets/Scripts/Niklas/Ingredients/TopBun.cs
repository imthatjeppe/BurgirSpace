using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/TopBun")]
public class TopBun : IngredientManager, IPooledObject
{
    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 0;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
    }

    public void OnObjectSpawn() { }
}