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

    void Start()
    {
        int n;
        for (int i = 0; i < wordRand.Length; i++)
        {
            n = Random.Range(0, words.Length);
            wordRand[i] = words[n];
            Debug.Log(wordRand[i]);
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
            Debug.Log(n);
        }
    }

    void Update()
    {
        if (GlobalVariables.startSound)
        {
            startSound();
            GlobalVariables.startSound= false;
        }
    }

    private void startSound()
    {

    }

}
