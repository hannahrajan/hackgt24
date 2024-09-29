using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCode : MonoBehaviour
{
    public GameObject puzzleone;
    public GameObject dialogue;
    public GameObject canvas;
    public static bool[] instantiated = new bool[6];

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puzzle1")
        {
            Debug.Log("COLLIDED");
            puzzleone.gameObject.SetActive(true);
            if (!instantiated[0])
            {
                GameObject start = Instantiate(dialogue, canvas.transform);
                start.SetActive(true);
                instantiated[0] = true;

            }
        }

        int index = 1;
        foreach (Strength strength in Globals.finalizedStrengths)
        {
            if (other.gameObject.tag == strength.colliderTag)
            {
                if (!instantiated[index])
                {
                    Debug.Log("COLLIDED WITH " + strength.colliderTag.ToUpper());
                    Globals.currentStrength = index - 1;
                    GameObject start = Instantiate(dialogue, canvas.transform);
                    start.SetActive(true);
                    instantiated[index] = true;
                }
            }
        }
        /*
        else if (other.gameObject.tag == "puzzle2")
        {
            
            SceneManager.LoadScene("Puzzle2Scene");
            Globals.returnPos = transform.position;


        }
        else if (other.gameObject.tag == "puzzle3") { 
            SceneManager.LoadScene("Puzzle3Scene");
            Globals.returnPos = transform.position;

        }
        Globals.returnPos = transform.position;
        */

    }
}
