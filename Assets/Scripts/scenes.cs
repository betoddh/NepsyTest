using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject scenesPanel;
    public void basic()
    {
        SceneManager.LoadScene("");
    }

    public void advance()
    {
        SceneManager.LoadScene("");
    }

    public void start()
    {
        startPanel.SetActive(false);
        scenesPanel.SetActive(true);
    }
}
