using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public TMP_Text gameTime;
    public TMP_Text badOrders;

    #region Singleton
    public static Stats instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        badOrders.text = "Bad Orders: " + ScoreManager.instance.badOrder;
    }

    void Update()
    {
        gameTime.text = "Game Time: " + GameManager.instance.difficultySetting.GameTime.ToString("f0");
    }
}
