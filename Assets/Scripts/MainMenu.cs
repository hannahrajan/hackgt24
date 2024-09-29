using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private bool madeCharacters = false;
    public void PlayGame() {
        SceneManager.LoadScene("MainLevelScene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void CharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelect");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
