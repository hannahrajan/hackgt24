using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCode : MonoBehaviour
{
    public GameObject puzzleone;
    public GameObject dialogue;
    public GameObject canvas;
    private bool instantiated;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puzzle1")
        {
            Debug.Log("COLLIDED");
            puzzleone.gameObject.SetActive(true);
            if (!instantiated)
            {
                GameObject start = Instantiate(dialogue, canvas.transform);
                start.SetActive(true);
                instantiated = true;

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
