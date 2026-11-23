using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scenes : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject scenesPanel;
    public GameObject instructionsPanel;
    public TMP_Text instructions;
    public Button startBtn;
    private int sceneNumber;
    public void basic()
    {
        instructions.text = "During this test, you will hear different words. When you hear the word RED, you must shoot the RED duck. When you hear any other word, do nothing. To shoot, press the trigger.";
        sceneNumber = 0;
        startBtn.onClick.AddListener(toScene);
        instructionsPanel.SetActive(true);
        scenesPanel.SetActive(false);
    }

    public void advance()
    {
        instructions.text = "During this test, you will hear different words. When you hear the word RED, you must shoot the YELLOW duck. When you hear the word YELLOW, you must shoot the RED duck. Finally, when you hear the word BLUE, you must shoot the BLUE duck. When you hear any other word, do nothing. To shoot, press the trigger.";
        sceneNumber=2;
        startBtn.onClick.AddListener(toScene);
        instructionsPanel.SetActive(true);
        scenesPanel.SetActive(false);
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
}
