using System.Collections.Generic;
using UnityEngine;

public class time : MonoBehaviour
{
    private float reactTime = 0;
    private List<float> allTimes = new List<float>();

    void Update()
    {
        if((GlobalVariables.isRed || GlobalVariables.isBlue || GlobalVariables.isYellow))
        {
            reactTime += Time.deltaTime;
            if (GlobalVariables.isCorrect)
            {
                GlobalVariables.isRed = false;
                GlobalVariables.isBlue = false;
                GlobalVariables.isYellow = false;
                GlobalVariables.isCorrect = false;
                allTimes.Add(reactTime);
                reactTime = 0;
            }
            else if (reactTime >= 3.8f)
            {

                reactTime = 0;
            }
        }

        if (GlobalVariables.finishTime)
        {
            reactionTime();
            GlobalVariables.finishTime = false;
        }
    }

    private void reactionTime()
    {

        if (allTimes.Count == 0)
        {
            GlobalVariables.time = -1;
        }
        else
        {
            float totalTime = 0;
            for (int i = 0; i < allTimes.Count; i++)
            {
                totalTime += allTimes[i];
            }
            float reactionTime = totalTime / allTimes.Count;
            GlobalVariables.time = reactionTime;
        }
        allTimes.Clear();
    }
}
