using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenes : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject scenesPanel;
    public TMP_Text instructions;
    public void basic()
    {
        instructions.text = "Durante esta prueba escucharas diferentes palabras, cuando escuches la palabra ROJO tendras que disparar al pato color rojo. Cuando escuches cualquier otra palabra, la que sea, no hagas nada.";
        SceneManager.LoadScene("");
    }

    public void advance()
    {
        instructions.text = "Durante esta prueba escucharas diferentes palabras, cuando escuches la palabra ROJO tendras que disparar al pato color verde, cuando escuches la plabra VERDE dispararas al pato color rojo y por ultimo cuando escuches las palabra AZUL" +
            " deberas disparar al pato color azul. Cuando escuches cualquier otra palabra, la que sea, no hagas nada.";
        //SceneManager.LoadScene("");
    }

    public void start()
    {
        startPanel.SetActive(false);
        scenesPanel.SetActive(true);
    }
}
