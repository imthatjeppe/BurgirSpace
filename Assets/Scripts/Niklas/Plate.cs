using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Plate : MonoBehaviour
{
    public void HoverEntered(string name)
    {
        BurgerManager.instance.AddIngredients(name);
    }

    public void HoverExited(string name)
    {
        BurgerManager.instance.RemoveIngredients(name);
    }

}
