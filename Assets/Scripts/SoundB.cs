using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundB : MonoBehaviour
{
    private string[] words = {
        "dog", "cat", "horse", "eagle", "rabbit", "tiger",
        "table", "chair", "door", "clock", "ball", "pencil", "star",
        "runs", "jumps", "sleeps", "sings", "plays", "walks", "takes", "bites", "listens",
        "park", "house", "school", "beach", "forest", "city",
        "green", "purple", "orange", "white", "black", "pink",
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
        int nColor;
        string[] color = { "red","blue", "yellow" };
   
        for (int i = 0; i < wordRand.Length; i++)
        {
            n = Random.Range(0, words.Length);
            wordRand[i] = words[n];
        }
        
        for (int i = 0; i < 36; i++)
        {
            do
            {
                n = Random.Range(0, wordRand.Length);

            } while (
                (n > 0 && wordRand[n - 1] == "red") ||
                (n < wordRand.Length - 1 && wordRand[n + 1] == "red") ||
                (n > 0 && wordRand[n - 1] == "blue") ||
                (n < wordRand.Length - 1 && wordRand[n + 1] == "blue") ||
                (n > 0 && wordRand[n - 1] == "yellow") ||
                (n < wordRand.Length - 1 && wordRand[n + 1] == "yellow")
            );

            nColor = Random.Range(0, color.Length);
            wordRand[n] = color[nColor];
        }
    }

    void Update()
    {
        if (GlobalVariables.startSound)
        {
            StartCoroutine(startSound());
            GlobalVariables.startSound = false;
        }
    }

    private IEnumerator startSound()
    {
        for (int i = 0; i < wordRand.Length; i++)
        {
            if (i != 0 && wordRand[i - 1] != "red")
            {
                GlobalVariables.isYellow = false;
            }
            else if (i != 0 && wordRand[i - 1] != "blue")
            {
                GlobalVariables.isBlue = false;
            }
            else if (i != 0 && wordRand[i - 1] != "yellow")
            {
                GlobalVariables.isRed = false;
            }

            if (wordRand[i] == "red")
            {
                GlobalVariables.isYellow = true;
            }
            else if (wordRand[i] == "blue")
            {
                GlobalVariables.isBlue = true;
            }
            else if (wordRand[i] == "red")
            {
                GlobalVariables.isYellow = true;
            }

            audioSource.PlayOneShot(audios[wordRand[i]]);
            
            yield return new WaitForSeconds(2f);
        }
        GlobalVariables.gameFinished = true;
    }
}
