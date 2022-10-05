using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerTutorial : Tutorial
{


    private bool isCurrentTutorial = false;
    public Transform cucumberTransform;

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

        if (other.transform == cucumberTransform)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }

}
