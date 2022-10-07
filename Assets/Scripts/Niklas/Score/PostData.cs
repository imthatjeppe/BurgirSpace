using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreData
{
    public string username, score;
    public ScoreData(string usernameData, string scoreData)
    {
        username = usernameData;
        score = scoreData;
    }
}

public class PostData : MonoBehaviour
{
    public TMP_Text username;
    public TMP_Text placeHolder;
    public TMP_Text scoreField;

    private static readonly HttpClient client = new HttpClient();

    #region Singleton
    public static PostData instance;
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
        scoreField.text = "Your Score: " + Save.instance.score;
    }

    string post = "http://borgir.xyz/api/score/create_score.php";
    string get = "https://borgir.xyz/api/score/read_score.php";
    string getOne = "http://borgir.xyz/api/score/read_single_score.php?userID=";
    string update = "http://borgir.xyz/api/score/update_score.php?userID=";

    public void SetKey(string key)
    {
        username.text += key;
        placeHolder.text += key;
    }

    public void CreateScore()
    {
        ScoreData scoreData = new ScoreData(placeHolder.text, "" + Save.instance.score);

        string values = JsonConvert.SerializeObject(scoreData);
        Debug.Log(values);

        StartCoroutine(Post(post, values));
    }

    IEnumerator Post(string url, string json)
    {

        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
            SceneManager.LoadScene(0);
        }
    }
}
