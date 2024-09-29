using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueThing : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject selfObject;
    string[] blorb = { "However, it's flowing pretty calmly.", "To make it across the river, you have several ways to approach the task."};
    string starter = "You have been walking for a while and come to a pretty deep river.";
    int count = 0;
    private void Start()
    {
        text.text = starter;
        PlayerMovement.canMove = false;
    }


    public void whenClick() {
        if (count < blorb.Length) {
            text.text = blorb[count];
            count++;

        } else
        {
            Destroy(selfObject);
            PlayerMovement.canMove = true;
        }  
        
    }


}
