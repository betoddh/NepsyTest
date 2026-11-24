using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenes : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject scenesPanel;
    public GameObject instructionsPanel;
    public GameObject resultPanel;
    public TMP_Text instructions;
    public TMP_Text correct;
    public TMP_Text commission;
    public TMP_Text omission;
    public TMP_Text inihibition;
    public TMP_Text time;
    public Button startBtn;
    private int sceneNumber;

    void Update()
    {
        if (GlobalVariables.gameFinished)
        {
            finalmenu();
            GlobalVariables.gameFinished = false;
        }
    }
    public void basic()
    {
        instructions.text = "During this test, you will hear different words. When you hear the word RED, you must shoot the RED duck. When you hear any other word, do nothing. To shoot, press the trigger.";
        sceneNumber = 0;
        GlobalVariables.posibleCorrect = 30;
        startBtn.onClick.AddListener(toScene);
        instructionsPanel.SetActive(true);
        scenesPanel.SetActive(false);
        GlobalVariables.caseA = true;
    }

    public void advance()
    {
        instructions.text = "During this test, you will hear different words. When you hear the word RED, you must shoot the YELLOW duck. When you hear the word YELLOW, you must shoot the RED duck. Finally, when you hear the word BLUE, you must shoot the BLUE duck. When you hear any other word, do nothing. To shoot, press the trigger.";
        sceneNumber=2;
        GlobalVariables.posibleCorrect = 36;
        startBtn.onClick.AddListener(toScene);
        instructionsPanel.SetActive(true);
        scenesPanel.SetActive(false);
        GlobalVariables.caseB = true;
    }

    public void start()
    {
        startPanel.SetActive(false);
        scenesPanel.SetActive(true);
    }

    private void toScene()
    {
        if (sceneNumber == 2)
        {
            SceneManager.LoadScene(sceneNumber);
        }
        scenesPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        startPanel.SetActive(false);
        GlobalVariables.startSound = true;
        GlobalVariables.gameStarted = true;
    }

    private void finalmenu()
    {
        correct.text=GlobalVariables.correct +"/" + GlobalVariables.posibleCorrect;
        commission.text=GlobalVariables.comi+ "";
        omission.text=GlobalVariables.omisi + "";
        inihibition.text=GlobalVariables.inhi + "";
        if (GlobalVariables.time == -1)
        {
            time.text = "No time reaction";
        }
        else
        {
            time.text = GlobalVariables.time + " seconds";
        }

        resultPanel.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(0);
        GlobalVariables.isRed = false;
        GlobalVariables.isYellow = false;
        GlobalVariables.isBlue = false;

        GlobalVariables.correct = 0;
        GlobalVariables.comi = 0;
        GlobalVariables.omisi = 0;
        GlobalVariables.inhi = 0;

        GlobalVariables.isCorrect = false;

        GlobalVariables.caseA = false;

        GlobalVariables.caseB = false;
    }
}
