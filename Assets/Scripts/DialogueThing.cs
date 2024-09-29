using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueThing : MonoBehaviour
{
    public TextMeshProUGUI text;
    string[] blorb = { "Text1", "Text2", "Text3", "Text4", "Text5" };
    int count = 0;
    private void Start()
    {
        text.text = "";
    }


    public void whenClick() {
        if (count < blorb.Length) {
            text.text = blorb[count];
            count++;

        } else
        {
            text.text = "";
        }  
        
    }


}
