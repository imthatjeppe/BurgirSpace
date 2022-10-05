using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Setting difficultySetting;

    public static GameStates gameState = GameStates.Menu;

    bool paused;

    #region Singleton
    public static GameManager instance;
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

    #region Setting GameStates
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var buildIndex = SceneManager.GetActiveScene().buildIndex;

        if(buildIndex == 1)
        {
            gameState = GameStates.Playing;
            Save.instance.sceneIndex = buildIndex;
            Save.instance.SaveAll();
            return;
        }

        if (buildIndex == 0 || buildIndex == 3) { gameState = GameStates.Menu; return; }
        if(buildIndex == 2) { gameState = GameStates.Loading; return; }
    }
    #endregion

    void Update()
    {
        if(gameState != GameStates.Playing) { return; }
        if(difficultySetting.GameTime <= 0) { ScoreManager.instance.badOrder = difficultySetting.maxBadOrders; return; }

        difficultySetting.GameTime -= Time.deltaTime;
    }

    public void PauseGame()
    {
        paused = !paused;

        if (paused)
        {
            Time.fixedDeltaTime = 0f;
            gameState = GameStates.Paused;
            //show pause screen
            return;
        }

        Time.fixedDeltaTime = 1f;
        gameState = GameStates.Playing;
        //take down pause screen
    }

    public void SetDifficulty(Setting setting)
    {
        difficultySetting = setting;
    }

    #region UtilityFunction
    public static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }
    #endregion

    void OnApplicationQuit()
    {
        Save.instance.SaveAll();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}

public enum GameStates
{
    Paused,
    Playing,
    Loading,
    Menu
}
