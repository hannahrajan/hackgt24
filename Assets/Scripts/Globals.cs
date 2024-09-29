﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public static Strength[] finalizedStrengths = {null, null, null, null, null};
    public static int currentSelected = 0;
    public static int currentStrength = 0;
    public static ObjectStorage os;
    public static Vector3 returnPos = new Vector3(0, 0, 0);

    public void Start()
    {
        
    }

    public static Strength[] getRow(int rowNumber)
    {
        return Enumerable.Range(0, ObjectStorage.strengths.GetLength(1))
                .Select(x => ObjectStorage.strengths[rowNumber, x])
                .ToArray();
    }

    public static GameObject getCurrentModelForCharacterSelection()
    {
        int row = currentSelected / 9;
        return ObjectStorage.strengths[row, currentStrength].model;
    }

    public static GameObject getCurrentSpriteForCharacterSelection()
    {
        int row = currentSelected / 9;
        return ObjectStorage.strengths[row, currentStrength].sprite;
    }

    public static void printStrengths()
    {
        foreach (Strength strength in finalizedStrengths) 
        {
            Debug.Log(strength);
        }
        
    }

    public static void SwitchScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
        for (int i = 0; i < finalizedStrengths.Length; i++) 
        {
            finalizedStrengths[i] = CharacterSelectManager.strengths[i];
        }
        currentStrength = -1;
        printStrengths();
    }

}

