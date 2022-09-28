using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pan : MonoBehaviour
{
    bool cooking = false;
    float cookTime = 0;
    public Color rawColor;
    public Color burntColor;

    bool isCycling = false;

    GameObject patty;

    void FixedUpdate()
    {
        if (!cooking) { return; }

        cookTime += Time.deltaTime;

        var iM = patty.GetComponent<Ingredient>().ingredientManager;

        var mat = patty.GetComponent<MeshRenderer>().material;

        if (iM is Cookable)
        {
            var cook = iM as Cookable;

            if (!isCycling)
                StartCoroutine(CycleMaterial(rawColor, burntColor, 80f, mat));

            if (cookTime < 20) { cook.states = CookStates.Raw; return; }

            if (cookTime >= 20 && cookTime < 40) { cook.states = CookStates.Rare; return; }

            if (cookTime >= 40 && cookTime < 60) { cook.states = CookStates.mediumRare; return; }

            if (cookTime >= 60 && cookTime < 80) { cook.states = CookStates.wellDone; return; }

            if (cookTime >= 80) { cook.states = CookStates.Burnt; return; }
        }
    }

    IEnumerator CycleMaterial(Color startColor, Color endColor, float cycleTime, Material mat)
    {
        Debug.Log("test");
        isCycling = true;
        float currentTime = 0;
        while (currentTime < cycleTime)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / cycleTime;
            Color currentColor = Color.Lerp(startColor, endColor, t);
            mat.color = currentColor;
            yield return null;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Patty"))
        {
            cooking = true;
            patty = other.gameObject;
            AudioManager.instance.PlayOnceLocal("Sizzling", gameObject);
        }

        if (other.gameObject.CompareTag("NonInteractable") || other.gameObject.CompareTag("Spatula"))
        {
            AudioManager.instance.PlayOnceLocal("Frying pan collision", gameObject);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Patty"))
        {
            cooking = false;
            isCycling = false;
        }
    }

}