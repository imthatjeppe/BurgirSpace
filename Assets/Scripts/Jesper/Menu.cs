using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject audio;
    [SerializeField] GameObject difficulity;
    [SerializeField] GameObject loadBtn;

    void Awake()
    {
        Save.instance.LoadAllSettings();

        var savedScene = Save.instance.CheckPreviousSave();
        if (savedScene == 0) { loadBtn.SetActive(false); return; }
        loadBtn.SetActive(true);
    }

    public void ToggleAudio()
    {
        //AudioManager.instance.PlayOnce("Menu Button");
        if (audio.activeInHierarchy == false) { audio.SetActive(true); }
        else { audio.SetActive(false); }
    }

    public void ToggleDifficulity()
    {
        //AudioManager.instance.PlayOnce("Menu Button");
        if (difficulity.activeInHierarchy == false) { difficulity.SetActive(true); }
        else { difficulity.SetActive(false); }
    }

}
