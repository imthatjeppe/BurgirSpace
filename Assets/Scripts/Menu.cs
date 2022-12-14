using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] List<GameObject> disable = new List<GameObject>();
    [SerializeField] GameObject panel;
    [SerializeField] GameObject audio;
    [SerializeField] GameObject difficulity;
    [SerializeField] GameObject loadBtn;
    [SerializeField] Slider masterSlider, sfxSlider, musicSlider;
    [SerializeField] TMP_Text movementType;

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

        AudioManager.instance.Play("Background Music 2");

        masterSlider.value = Save.instance.master;
        sfxSlider.value = Save.instance.sfx;
        musicSlider.value = Save.instance.music;

        string movement;
        if (Save.instance.walking)
        {
            movement = "Walking";
        }
        else
        {
            movement = "Teleporting";
        }

        movementType.text = "Movement: " + movement;

    }

    public void CheckTutorial()
    {
        if(Save.instance.tutorial == true)
        {
            LevelLoader.instance.LoadLoading("Main Level");
            Save.instance.ResetData();
        }
        else
        {
            foreach(GameObject g in disable)
            {
                g.SetActive(false);
            }
            panel.SetActive(true);
        }
    }

    public void SetTutorial()
    {
        Save.instance.tutorial = true;
        Save.instance.SaveAll();
    }

    public void SwapMovement()
    {
        Save.instance.walking = !Save.instance.walking;
        Save.instance.SaveAll();


        string movement;
        if (Save.instance.walking)
        {
            movement = "Walking";
        }
        else
        {
            movement = "Teleporting";
        }

        movementType.text = "Movement: " + movement;
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
