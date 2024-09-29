using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Strength
{
    public int id;
    public string name;
    public GameObject model;
    public GameObject sprite;
    public string colliderTag;
    public Dictionary<string, int[]> dialogue;
    public Dictionary<string, int> points;
    private bool instantiated = false;

    public Strength(int id, string name, GameObject model, GameObject sprite, string colliderTag, Dictionary<string, int[]> dialogue)
    {
        this.id = id;
        this.name = name;
        this.model = model;
        this.sprite = sprite;
        this.colliderTag = colliderTag;
        this.dialogue = dialogue;
        points = new Dictionary<string, int>
        {
            { "Time", 0 },
            { "Likability", 0 },
            { "Health / Wellbeing", 0},
            { "Fulfillment / Esteem", 0 },
            { "Creativity", 0 }
        };
    }


    public void addPoints(int puzzle)
    {
        int index = 0;
        foreach (int[] val in dialogue.Values)
        {
            if (puzzle == index)
            {
                foreach (int item in val){
                    foreach (var key in points.Keys)
                    {
                        points[key] += item;
                    }
                }
            }
        }
            
    }

    private string dialoguePrint()
    {
        string returnStr = "";
        foreach (var key in dialogue.Keys)
        {
            returnStr = key + ": " + dialogue[key] + ", ";
        }
        return returnStr.Substring(0, returnStr.Length - 2);
    }

    public override string ToString()
    {
        return id + " {" +
            name + ", Model: " +
            model.name + ", Sprite: " +
            sprite.name + ", Collider: " +
            colliderTag + ", Dialogue: " +
            dialoguePrint();
    }
}
