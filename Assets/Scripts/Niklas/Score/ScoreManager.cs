using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    float score = 0;
    int badOrder = 0;
    int maxBadOrder = 5;

    #region Singleton
    public static ScoreManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    void Update()
    {
        if(badOrder < maxBadOrder) { return; }
        if(GameManager.gameState != GameStates.Playing) { return; }
        GameManager.gameState = GameStates.Loading;
        Save.instance.SaveAll();
        LevelLoader.instance.LoadLoading("GameOver");
    }

    public void UpdateScore(float completionPercentage, float orderTime, float waitTime, CookStates desiredPattyState, CookStates currentPattyState)
    {
        float deliveryMultiplier = 1000;
        score = deliveryMultiplier * (completionPercentage / 100);

        Debug.Log("Desired: " + desiredPattyState);
        Debug.Log("Current: " + currentPattyState);

        if (completionPercentage < 30 || orderTime > waitTime || currentPattyState == CookStates.Raw || currentPattyState == CookStates.Burnt || currentPattyState != desiredPattyState)
        {
            badOrder++;
            Save.instance.badOrder = badOrder;
            Debug.Log("Bad Orders: " + badOrder);
        }
        Save.instance.score = score;
        Save.instance.SaveAll();

        Debug.Log("Score: " + score);
    }
}
