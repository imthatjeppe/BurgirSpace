using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTutorial : Tutorial
{


    private bool isCurrentTutorial = false;
    public Transform PlayerTransform;

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

        if (other.transform == PlayerTransform)
        {
            TutorialManager.Instance.CompletedTutorial();
            isCurrentTutorial = false;
        }

    }

}
