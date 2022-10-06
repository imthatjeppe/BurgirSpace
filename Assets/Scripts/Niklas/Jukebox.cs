using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{
    public List<string> music = new List<string>();

    void Start()
    {
        AudioManager.instance.PlayOnceLocal("Jukebox Start", gameObject);

        AudioManager.instance.PlayLocal(music[Random.Range(0, music.Count)], gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlayOnceLocal("Jukebox Start", gameObject);

        foreach(Transform child in gameObject.transform)
        {
            if(child != null)
                Destroy(child.gameObject);
        }

        int randomSong = Random.Range(0, music.Count);

        AudioManager.instance.PlayLocal(music[randomSong], gameObject);
    }
}
