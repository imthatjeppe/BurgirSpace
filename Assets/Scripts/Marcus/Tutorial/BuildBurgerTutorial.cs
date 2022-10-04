using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBurgerTutorial : Tutorial
{
    private bool isCurrentTutorial = false;
    public Transform BurgerTransform;

    public override void CheckIfHappening()
    {
        isCurrentTutorial = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCurrentTutorial)
        {
            return;
        }

        if (other.transform == BurgerTransform)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }
}
