using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//used like this LevelLoader.Instance.LoadLoading(scene);
public class LevelLoader : MonoBehaviour
{
    #region Singleton
    public static LevelLoader instance;
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

    public async void LoadLoading(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync("Loading");
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);

        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
        LoadScene(sceneName);

    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            GameObject.FindGameObjectWithTag("Loading").GetComponent<Image>().fillAmount = scene.progress;

        } while (scene.progress < 0.9f);

        scene.allowSceneActivation = true;
    }
}