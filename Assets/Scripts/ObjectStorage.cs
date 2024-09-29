using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectStorage : MonoBehaviour
{
    //all models defined (sadly, manually)
    public GameObject redE;
    public GameObject orangeE;
    public GameObject yellowE;
    public GameObject greenE;
    public GameObject blueE;

    public GameObject redI;
    public GameObject orangeI;
    public GameObject yellowI;
    public GameObject greenI;
    public GameObject blueI;

    public GameObject redR;
    public GameObject orangeR;
    public GameObject yellowR;
    public GameObject greenR;
    public GameObject blueR;

    public GameObject redS;
    public GameObject orangeS;
    public GameObject yellowS;
    public GameObject greenS;
    public GameObject blueS;

    public GameObject redESprite;
    public GameObject orangeESprite;
    public GameObject yellowESprite;
    public GameObject greenESprite;
    public GameObject blueESprite;

    public GameObject redISprite;
    public GameObject orangeISprite;
    public GameObject yellowISprite;
    public GameObject greenISprite;
    public GameObject blueISprite;

    public GameObject redRSprite;
    public GameObject orangeRSprite;
    public GameObject yellowRSprite;
    public GameObject greenRSprite;
    public GameObject blueRSprite;

    public GameObject redSSprite;
    public GameObject orangeSSprite;
    public GameObject yellowSSprite;
    public GameObject greenSSprite;
    public GameObject blueSSprite;

    private static GameObject[,] strengthsModels = new GameObject[4,5];
    private static GameObject[,] strengthsSprites = new GameObject[4, 5];
    public static string[,] strengthsNames =
    {
        {"Achiever", "Arranger", "Belief", "Consistency", "Deliberative", "Discipline", "Focus", "Responsibility", "Restorative"},
        {"Activator", "Command", "Communication", "Competition", "Maximizer", "Self-Assurance", "Significance", "Woo", "NULL"},
        {"Adaptability", "Connectedness", "Developer", "Empathy", "Harmony", "Includer", "Individualization", "Positivity", "Relator"},
        {"Analytical", "Context", "Futuristic", "Ideation", "Input", "Intellection", "Learner", "Strategic", "NULL"}
    };


    public static Strength[,] strengths = new Strength[4, 9];

    public void Start()
    {
        strengthsModels[0, 0] = redE;
        strengthsModels[0, 1] = orangeE;
        strengthsModels[0, 2] = yellowE;
        strengthsModels[0, 3] = greenE;
        strengthsModels[0, 4] = blueE;

        strengthsModels[1, 0] = redI;
        strengthsModels[1, 1] = orangeI;
        strengthsModels[1, 2] = yellowI;
        strengthsModels[1, 3] = greenI;
        strengthsModels[1, 4] = blueI;

        strengthsModels[2, 0] = redR;
        strengthsModels[2, 1] = orangeR;
        strengthsModels[2, 2] = yellowR;
        strengthsModels[2, 3] = greenR;
        strengthsModels[2, 4] = blueR;

        strengthsModels[3, 0] = redS;
        strengthsModels[3, 1] = orangeS;
        strengthsModels[3, 2] = yellowS;
        strengthsModels[3, 3] = greenS;
        strengthsModels[3, 4] = blueS;

        strengthsSprites[0, 0] = redESprite;
        strengthsSprites[0, 1] = orangeESprite;
        strengthsSprites[0, 2] = yellowESprite;
        strengthsSprites[0, 3] = greenESprite;
        strengthsSprites[0, 4] = blueESprite;

        strengthsSprites[1, 0] = redISprite;
        strengthsSprites[1, 1] = orangeISprite;
        strengthsSprites[1, 2] = yellowISprite;
        strengthsSprites[1, 3] = greenISprite;
        strengthsSprites[1, 4] = blueISprite;

        strengthsSprites[2, 0] = redRSprite;
        strengthsSprites[2, 1] = orangeRSprite;
        strengthsSprites[2, 2] = yellowRSprite;
        strengthsSprites[2, 3] = greenRSprite;
        strengthsSprites[2, 4] = blueRSprite;

        strengthsSprites[3, 0] = redSSprite;
        strengthsSprites[3, 1] = orangeSSprite;
        strengthsSprites[3, 2] = yellowSSprite;
        strengthsSprites[3, 3] = greenSSprite;
        strengthsSprites[3, 4] = blueSSprite;

        Debug.Log("INITIALIZED");

        for (int i = 0; i < strengthsNames.LongLength; i++)
        {
            int x = i % 9;
            int y = i / 9;
            string name = strengthsNames[y, x];
            if (name.Equals("NULL"))
            {
                strengths[y, x] = null;
            }
            else
            {
                strengths[y, x] = new Strength(i, name, strengthsModels[y, Globals.currentStrength], strengthsSprites[y, Globals.currentStrength], null);
                //Debug.Log(strengths[y, x]);
            }
        }

        DialogueManager.FormatCSVFile();


    }

    public static GameObject[] getRow(int rowNumber)
    {
        return Enumerable.Range(0, strengthsModels.GetLength(1))
                .Select(x => strengthsModels[rowNumber, x])
                .ToArray();
    }

    public static void SwitchScene(int sceneid)
    {
        Globals.SwitchScene(sceneid);
    }

}

