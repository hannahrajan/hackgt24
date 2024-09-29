using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class DialogueManager
{

    // Update is called once per frame
    public static void FormatCSVFile()
    {
        StreamReader strReader = new StreamReader(Path.GetRelativePath("Assets", "Assets/Dialogue.csv"));
        bool endOfFile = false;
        Dictionary<string, Dictionary<string, int[]>> allDialoguePoints = new Dictionary<string, Dictionary<string, int[]>>();
        while (!endOfFile)
        {
            string dataStr = strReader.ReadLine();
            Debug.Log(dataStr);
            if (dataStr == null)
            {
                endOfFile = true;
                break;
            }
            //Debug.Log(dataStr);
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var dataValues = CSVParser.Split(dataStr);
            string name = dataValues[0];
            Dictionary<string, int[]> dialoguePoints = new Dictionary<string, int[]>();

            for (int i = 1; i < dataValues.Length; i+=2)
            {
                dialoguePoints[dataValues[i]] = splitPoints(dataValues[i + 1]);
                foreach(int integer in dialoguePoints[dataValues[i]])
                {
                    Debug.Log(integer);
                }
            }
            allDialoguePoints[name] = dialoguePoints;
            //Debug.Log(dialoguePoints);
        }
    }

    private static int[] splitPoints(string points)
    {
        char[] charSplit = points.ToCharArray();
        foreach(char s in charSplit)
        {
            Debug.Log(s);
        }
        int[] returnPoints = new int[4];
        int index = 1;
        for (int i = 0; i < 4; i++)
        {
            string potentialInt = "";
            while (!charSplit[index].Equals(':') && !charSplit[index].Equals('0') && index < charSplit.Length) {
                potentialInt += charSplit[index];
                index++;
            }
            try
            {
                returnPoints[i] = Int32.Parse(potentialInt);
            } catch (FormatException e)
            {
                continue;
            }
            
        }
        foreach (char s in charSplit)
        {
            Debug.Log(s);
        }
        return returnPoints;
    }
}
