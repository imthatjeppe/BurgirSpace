using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager: MonoBehaviour
{
    public List<Tutorial> Tutorials = new List<Tutorial>();

    public TextMeshProUGUI expText;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TutorialManager>();
            }

            if (instance == null)
            {
                Debug.Log("There is no tutorial manager");
            }

            return instance;
        }
    }

    private Tutorial currentTutorial;

    void Start()
    {
        SetNextTutorial(0);
    }


    void Update()
    {
        if (currentTutorial)
        {
            currentTutorial.CheckIfHappening();
        }
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.Order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = GetTutorialByOrder(currentOrder);

        if(!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }

        expText.text = currentTutorial.Explanation;
    }

    public void CompletedAllTutorials()
    {
        expText.text = "You have completed the tutorial! Press # to exit the tutorial.";
    }

    public Tutorial GetTutorialByOrder(int Order)
    {
        for (int i = 0; i < Tutorials.Count; i++)
        {
            if (Tutorials[i].Order == Order)
            {
                return Tutorials[i];
            } 
        }

        return null;
    }
}
