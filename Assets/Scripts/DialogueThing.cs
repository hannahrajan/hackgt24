using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueThing : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject selfObject;
    public Sprite selfSprite;
    string[] dialogue = { "You have been walking for a while and come to a pretty deep river.", "However, it's flowing pretty calmly.", "To make it across the river, you have several ways to approach the task."};
    int count = 0;
    public void Start()
    {
        if (Globals.currentStrength != -1)
        {

            dialogue = new string[10];
            int index = 0;
            foreach (string key in Globals.finalizedStrengths[Globals.currentStrength].dialogue.Keys)
            {
                foreach (string talk in key.Split("."))
                {
                    dialogue[index] = talk;
                    index++;
                }
            }
        }
        
        text.text = dialogue[0];
        PlayerMovement.canMove = false;
    }


    public void whenClick() {
        if (count < dialogue.Length && dialogue[count] != null) {
            text.text = dialogue[count];
            count++;

        } else
        {
            Destroy(selfObject);
            PlayerMovement.canMove = true;
            CollisionCode.instantiated[Globals.currentStrength + 1] = false;
        }  
        
    }


}
