using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Globals : MonoBehaviour
{
    public static Strength[] finalizedStrengths = new Strength[5];
    public static int currentSelected = 0;
    public static int currentStrength = 0;
    public static ObjectStorage os;

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

    public static void updateStrengths(int id, Strength strength)
    {
        finalizedStrengths[id] = strength;
        Debug.Log(finalizedStrengths[id]);
    }

    public static void SwitchScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }

}

