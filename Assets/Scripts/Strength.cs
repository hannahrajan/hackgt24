using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Strength
{
    public int id;
    public string name;
    public GameObject model;
    public GameObject sprite;
    public string dialogue;
    public Dictionary<string, int> points;

    public Strength(int id, string name, GameObject model, GameObject sprite, string dialogue)
    {
        this.id = id;
        this.name = name;
        this.model = model;
        this.sprite = sprite;
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

    public void addPoints(int time, int like, int health, int fulfill, int create)
    {
        points["Time"] += time;
        points["Likeability"] += like;
        points["Health / Wellbeing"] += health;
        points["Fulfillment / Esteem"] += fulfill;
        points["Creativity"] += create;
    }

    public override string ToString()
    {
        return id + " {" +
            name + ", Model: " +
            model.name + ", Sprite: " +
            sprite.name + ", ";
    }
}
