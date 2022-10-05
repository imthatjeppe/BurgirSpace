using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetchupTutorial : Tutorial
{


    private bool isCurrentTutorial = false;
    public Transform ketchupTransform;

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

        if (other.transform == ketchupTransform)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }

}
