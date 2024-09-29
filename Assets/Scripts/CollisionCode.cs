using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionCode : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puzzle1")
        {
            SceneManager.LoadScene("Puzzle1Scene");
            Globals.returnPos = transform.position;

        }
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

    }
}
