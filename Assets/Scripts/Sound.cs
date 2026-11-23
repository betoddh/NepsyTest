using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private string[] words = {
        "dog", "cat", "horse", "eagle", "rabbit", "tiger",
        "table", "chair", "door", "clock", "ball", "pencil", "star",
        "runs", "jumps", "sleeps", "sings", "plays", "walks", "takes", "bites", "listens",
        "park", "house", "school", "beach", "forest", "city",
        "yellow", "purple", "orange", "white", "black", "pink", "blue", "green",
        "tomorrow", "never", "always", "maybe", "far", "near",
        "thing", "soon", "rock", "late", "low", "now", "chance"
    };

    private string[] wordRand = new string[144];

    public AudioSource audioSource;

    Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();

    void Start()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>("Audios");

        foreach (AudioClip clip in clips)
        {
            audios.Add(clip.name.ToLower(), clip);
        }

        int n;
        for (int i = 0; i < wordRand.Length; i++)
        {
            n = Random.Range(0, words.Length);
            wordRand[i] = words[n];
        }

        for (int i = 0;i < 30; i++)
        {
            do
            {
                n = Random.Range(0, wordRand.Length);

            } while (
                (n > 0 && wordRand[n - 1] == "red") ||
                (n < wordRand.Length - 1 && wordRand[n + 1] == "red")
            );

            wordRand[n] = "red";
        }
    }

    void Update()
    {
        if (GlobalVariables.startSound)
        {
            StartCoroutine(startSound());
            GlobalVariables.startSound= false;
        }

        
    }

    private IEnumerator startSound()
    {
        for(int i = 0; i < wordRand.Length; i++)
        {
            if(i != 0 && wordRand[i-1] != "red")
            {
                GlobalVariables.isRed = false;
            }

            if(wordRand[i] == "red")
            {
                GlobalVariables.isRed = true;
            }
            audioSource.PlayOneShot(audios[wordRand[i]]);
            yield return new WaitForSeconds(2f);
        }
        GlobalVariables.gameFinished = true;
    }

}
