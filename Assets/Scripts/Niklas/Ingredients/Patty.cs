using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = "Ingredient/Patty")]
public class Patty : Cookable
{
    [SerializeField] CookStates s;

    [SerializeField] string iName;
    [SerializeField] Sprite iIcon;

    int idNum = 1;

    void OnEnable()
    {
        IngredientName = iName;
        Id = idNum;
        Icon = iIcon;
        States = s;
    }

    public void OnObjectSpawn() { }

}