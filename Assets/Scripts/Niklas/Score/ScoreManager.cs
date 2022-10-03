using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    float score = 0;
    [HideInInspector] public int badOrder = 0;
    int maxBadOrder;

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

    void Start()
    {
        maxBadOrder = GameManager.instance.difficultySetting.maxBadOrders;
    }

    void Update()
    {
        if(badOrder < maxBadOrder) { return; }
        if(GameManager.gameState != GameStates.Playing) { return; }
        GameManager.gameState = GameStates.Loading;
        Save.instance.SaveAll();
        LevelLoader.instance.LoadLoading("GameOver");
    }

    public void UpdateScore(float completionPercentage, float orderTime, float waitTime, CookStates desiredPattyState, CookStates currentPattyState, float bonusMultiplier)
    {
        float deliveryMultiplier = 1000 + bonusMultiplier;

        if (currentPattyState == CookStates.Burnt || currentPattyState == CookStates.Raw) { deliveryMultiplier = 0; }

        score = deliveryMultiplier * (completionPercentage / 100);

        if (completionPercentage < 30 || orderTime > waitTime || currentPattyState != desiredPattyState)
        {
            badOrder++;
            Stats.instance.badOrders.text = "Bad Orders: " + badOrder;
            Save.instance.badOrder = badOrder;
        }
        Save.instance.score = score;
        Save.instance.SaveAll();
    }
}
