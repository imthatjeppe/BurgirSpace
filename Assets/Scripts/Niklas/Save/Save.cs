using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [HideInInspector] public int sceneIndex;
    [HideInInspector] public float score;
    [HideInInspector] public int badOrder;
    [HideInInspector] public float master, music, sfx;
    [HideInInspector] public bool walking, tutorial;

    #region Singleton
    public static Save instance;
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

    public void SaveAll()
    {
        SaveData.Save(this);
    }

    public int CheckPreviousSave()
    {
        GameData data = SaveData.Load();
        return data.sceneIndex;
    }

    public void LoadSavedScene()
    {
        string sceneString = GameManager.NameFromIndex(sceneIndex);
        LevelLoader.instance.LoadLoading(sceneString);
    }

    public void ResetData()
    {
        sceneIndex = 0;
        score = 0;
        badOrder = 0;
        SaveAll();
    }

    public void LoadAll()
    {
        GameData data = SaveData.Load();
        sceneIndex = data.sceneIndex;
        score = data.score;
        badOrder = data.badOrder;
    }

    public void LoadAllSettings()
    {
        GameData data = SaveData.Load();
        master = data.master;
        sfx = data.sfx;
        music = data.music;
        walking = data.walking;
        tutorial = data.tutorial;
        AudioManager.instance.SetMasterVolume(master);
        AudioManager.instance.SetSfxVolume(sfx);
        AudioManager.instance.SetMusicVolume(music);
    }
}