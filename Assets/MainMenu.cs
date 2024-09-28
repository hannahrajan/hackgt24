using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("MainLevelScene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void CharacterSelection()
    {
        SceneManager.LoadScene("CharacterSelectionScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
