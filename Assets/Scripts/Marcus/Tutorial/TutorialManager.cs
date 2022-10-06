using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager: MonoBehaviour
{
    public float textDelay = 0.1f;

    private string currentText = "";

    private Coroutine routine;

    public string fullText;

    public List<Tutorial> Tutorials = new List<Tutorial>();

    public TextMeshProUGUI tutorialText;

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

    void Start()
    {  
        SetNextTutorial(0);
        fullText = tutorialText.text;
        StartCoroutine(ShowText(fullText));
    }

    IEnumerator ShowText(string fullText)
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            tutorialText.text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
    }

    private Tutorial currentTutorial;




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

        if (routine != null)
        {
            StopCoroutine(routine);
        }
        tutorialText.text = currentTutorial.Explanation;
        
        routine = StartCoroutine(ShowText(currentTutorial.Explanation));
    }

    public void CompletedAllTutorials()
    {
        tutorialText.text = "You have completed the tutorial! Press # to exit the tutorial.";
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
