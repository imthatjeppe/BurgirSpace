using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject audio;
    [SerializeField] GameObject difficulity;
    [SerializeField] GameObject loadBtn;
    [SerializeField] Slider masterSlider, sfxSlider, musicSlider;

    void Awake()
    {
        Save.instance.LoadAllSettings();

        var savedScene = Save.instance.CheckPreviousSave();
        if (savedScene == 0) { loadBtn.SetActive(false); return; }
        loadBtn.SetActive(true);
    }

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) { return; }
        masterSlider.value = Save.instance.master;
        sfxSlider.value = Save.instance.sfx;
        musicSlider.value = Save.instance.music;
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

    public void SetMasterValue()
    {
        AudioManager.instance.SetMasterVolume(masterSlider.value);
        Save.instance.master = masterSlider.value;
    }

    public void SetSfxValue()
    {
        AudioManager.instance.SetSfxVolume(sfxSlider.value);
        Save.instance.sfx = sfxSlider.value;
    }

    public void SetMusicValue()
    {
        AudioManager.instance.SetMusicVolume(musicSlider.value);
        Save.instance.music = musicSlider.value;
    }

}
