using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public float score;
    int badOrder = 0;
    [SerializeField] int maxBadOrder = 5;

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
        //GameOver;
    }

    public void UpdateScore(float completionPercentage, float orderTime, float waitTime)
    {
        float deliveryMultiplier = 1000;
        score = deliveryMultiplier * (completionPercentage / 100);

        if(completionPercentage < 30 || orderTime > waitTime)
        {
            badOrder++;
        }

        Debug.Log("Score: " + score);
    }
}
