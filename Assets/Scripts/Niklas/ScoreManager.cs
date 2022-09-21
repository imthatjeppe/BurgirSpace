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

public class ScoreManager : MonoBehaviour
{
    [HideInInspector] public float score;
    int badOrder = 0;
    [SerializeField] int maxBadOrder = 5;

    public TMP_InputField usernameField;
    public TMP_Text scoreText;

    public GameObject GameOver;

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

    void Start()
    {
        scoreText.text = ""+score;
    }

    void Update()
    {
        if(badOrder < maxBadOrder) { return; }
        GameOver.SetActive(true);
        maxBadOrder = 0;
    }

    public void UpdateScore(float completionPercentage, float orderTime, float waitTime)
    {
        float deliveryMultiplier = 1000;
        score = deliveryMultiplier * (completionPercentage / 100);

        if(completionPercentage < 30 || orderTime > waitTime)
        {
            badOrder++;
            Debug.Log("Bad Order");
        }

        scoreText.text = "Your score: " + score + "!";
    }

    private static readonly HttpClient client = new HttpClient();

    string post = "http://borgir.xyz/api/score/create_score.php";
    string get = "https://borgir.xyz/api/score/read_score.php";
    string getOne = "http://borgir.xyz/api/score/read_single_score.php?userID=";
    string update = "http://borgir.xyz/api/score/update_score.php?userID=";

    public void CreateScore()
    {
        ScoreData scoreData = new ScoreData(usernameField.text, ""+score);

        string values = JsonConvert.SerializeObject(scoreData);
        Debug.Log(values);

        StartCoroutine(PostData(post, values));
    }

    IEnumerator PostData(string url, string json)
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
