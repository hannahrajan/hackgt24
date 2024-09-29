using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLevel : MonoBehaviour
{
    public void OptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

}
