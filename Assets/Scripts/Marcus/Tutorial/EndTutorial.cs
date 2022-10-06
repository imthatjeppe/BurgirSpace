using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{

    public void End()
    {
        GameObject.FindGameObjectWithTag("LevelLoader").GetComponent<LevelLoader>().LoadLoading("Main Level");
        GameObject.FindGameObjectWithTag("SaveManager").GetComponent<Save>().ResetData();
    }
}
