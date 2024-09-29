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

        var dictionaryOfDictionaries = new Dictionary<string, Dictionary<string, int[]>>
        {
            { "Analytical", new Dictionary<string, int[]>
                {
                    { "ou build a medium-sized raft together. Based on who can swim well and who cannot, you split the group into those that will sit in the raft and those that will swim alongside.", new int[] { 125, 175, 200, 175 } }
                }
            },
            { "Context", new Dictionary<string, int[]>
                {
                    { "You know from walking by this river in the past that there is a section where it is shallower and thinner, so you guide your group to this detour and cross with minimal difficulty.", new int[] { 125, 175, 200, 175 } }
                }
            },
            { "Futuristic", new Dictionary<string, int[]>
                {
                    { "You decide to cut down a couple nearby tall trees to make a raft. You want to avoid getting wet, in case it becomes cold later on and someone gets sick.", new int[] { 150, 150, 200, 125 } }
                }
            },
            { "Ideation", new Dictionary<string, int[]>
                {
                    { "You come up with the idea of climbing the trees over the river and getting across by hopping across the branches.", new int[] { 125, 175, 175, 150 } }
                }
            },
            { "Input", new Dictionary<string, int[]>
                {
                    { "From prior knowledge, you recognize the river as calm and clear enough to swim in safely. The group swims across quickly.", new int[] { 200, 150, 125, 125 } }
                }
            },
            { "Intellection", new Dictionary<string, int[]>
                {
                    { "You think up an idea to swim across the river, but also build a raft for your supplies, clothes, and those in the group who are weaker swimmers to float across on.", new int[] { 175, 150, 150, 175 } }
                }
            },
            { "Learner", new Dictionary<string, int[]>
                {
                    { "You have had experience learning raft-building, and help guide your team to construct a simple and efficient one.", new int[] { 150, 175, 200, 125 } }
                }
            },
            { "Strategic", new Dictionary<string, int[]>
                {
                    { "For the sake of saving time, effort, and keeping everyone dry, you decide to build a small raft and float people across a few at a time, with only one or two people needing to swim to ferry everyone across quickly.", new int[] { 175, 150, 175, 150 } }
                }
            },
            { "Adaptability", new Dictionary<string, int[]>
                {
                    { "You decide that it will be fine to take a longer path that avoids the river instead of the current one.", new int[] { 125, 150, 175, 125 } }
                }
            },
            { "Connectedness", new Dictionary<string, int[]>
                {
                    { "You decide that this is for the best because you can now take a walk along the river and marvel at the nature while finding an alternative route, where you eventually find a shallower part of the river.", new int[] { 125, 175, 175, 150 } }
                }
            },
            { "Developer", new Dictionary<string, int[]>
                {
                    { "You decide to teach everyone who doesn't know how to swim to swim so you can cross the river.", new int[] { 125, 175, 150, 150 } }
                }
            },
            { "Empathy", new Dictionary<string, int[]>
                {
                    { "You decide to create a circle to scream into nature to vent anger at this hardship in a positive way before you continue to look for a way to cross, where you eventually find a shallower part of the river.", new int[] { 150, 150, 175, 175 } }
                }
            },
            { "Harmony", new Dictionary<string, int[]>
                {
                    { "You decide to ask everyone their thoughts on how to approach the situation and include aspects of all of the ideas, eventually finding a different path at a narrower part of the stream that you were all able to reach with everyone's input.", new int[] { 125, 200, 175, 150 } }
                }
            },
            { "Includer", new Dictionary<string, int[]>
                {
                    { "You find those who seem to be dragging behind and ask what they want to do to cross and promote the idea to the whole group.", new int[] { 175, 150, 200, 125 } }
                }
            },
            { "Individualization", new Dictionary<string, int[]>
                {
                    { "You give everyone specific tasks based on their expertise to help create a raft that you then use to cross the river.", new int[] { 175, 175, 150, 175 } }
                }
            },
            { "Positivity", new Dictionary<string, int[]>
                {
                    { "You cheer everyone up and decide that some time walking along the river may help, where you find a shallower part of the river to cross.", new int[] { 175, 200, 175, 125 } }
                }
            },
            { "Realtor", new Dictionary<string, int[]>
                {
                    { "You pick out one person and start connecting with them, eventually finding out that they know where on the river there may be a shallower part to cross over on from studying about river geography before.", new int[] { 150, 150, 150, 200 } }
                }
            },
            { "Activator", new Dictionary<string, int[]>
                {
                    { "You decide that to get to camp on time, everyone needs to swim across quickly and help others if necessary.", new int[] { 200, 125, 150, 125 } }
                }
            },
            { "Command", new Dictionary<string, int[]>
                {
                    { "You remind everyone that the point of this experience was to grow through the hardship and encourage everyone to swim across.", new int[] { 175, 150, 150, 150 } }
                }
            },
            { "Communication", new Dictionary<string, int[]>
                {
                    { "You ask if anyone has any objections to swimming across, meet those objections with reasonable solutions, and get everyone to the other side.", new int[] { 150, 175, 150, 150 } }
                }
            },
            { "Competition", new Dictionary<string, int[]>
                {
                    { "You make it a race to encourage everyone to swim as fast as they can across.", new int[] { 200, 125, 150, 175 } }
                }
            },
            { "Maximizer", new Dictionary<string, int[]>
                {
                    { "You gather people with the skills to make a raft and have them teach everyone else how to to get across in a more timely manner.", new int[] { 175, 150, 175, 175 } }
                }
            },
            { "Self-Assurance", new Dictionary<string, int[]>
                {
                    { "You tell everyone that they can try to make a raft if they want, but that you will be swimming and they need to hurry either way.", new int[] { 200, 125, 150, 125 } }
                }
            },
            { "Significance", new Dictionary<string, int[]>
                {
                    { "You find all of the materials you can to make a raft from the area around the river.", new int[] { 125, 150, 200, 175 } }
                }
            },
            { "Woo", new Dictionary<string, int[]>
                {
                    { "You find all of the people who seem to not be contributing to the conversation and ask their opinions, finally deciding to build a raft with different parts to meet everyone's wants.", new int[] { 125, 175, 175, 150 } }
                }
            },
            { "Achiever", new Dictionary<string, int[]>
                {
                    { "You decide to build a raft no matter how long it takes with the material you've been given.", new int[] { 125, 150, 200, 125 } }
                }
            },
            { "Arranger", new Dictionary<string, int[]>
                {
                    { "You place people in groups to go search for an alternative route, eventually finding a shallower part of the river.", new int[] { 150, 175, 175, 125 } }
                }
            },
            { "Belief", new Dictionary<string, int[]>
                {
                    { "You meditate on the options and decide on taking the land route that is beneficial for the most people, even if it takes longer.", new int[] { 125, 150, 175, 125 } }
                }
            },
            { "Consistency", new Dictionary<string, int[]>
                {
                    { "You decide to make a raft because you have experience with raft building from other camping trips.", new int[] { 150, 200, 200, 150 } }
                }
            },
            { "Deliberative", new Dictionary<string, int[]>
                {
                    { "You make a list of all of the possible plus sides and downsides and decide to find a way on land with a backup raft idea.", new int[] { 125, 200, 175, 175 } }
                }
            },
            { "Discipline", new Dictionary<string, int[]>
                {
                    { "You find all of the materials you can to make a raft.", new int[] { 125, 175, 175, 200 } }
                }
            },
            { "Focus", new Dictionary<string, int[]>
                {
                    { "You decide to encourage others to swim across to keep on the original schedule.", new int[] { 200, 150, 150, 125 } }
                }
            },
            { "Responsibility", new Dictionary<string, int[]>
                {
                    { "You decide to find a quick solution, swimming across, so everyone can have time to rejuvenate at the end of camp as promised.", new int[] { 200, 150, 150, 125 } }
                }
            },
            { "Restorative", new Dictionary<string, int[]>
                {
                    { "You decide that those who want to swim can ferry those who don't across on a raft.", new int[] { 150, 200, 175, 200 } }
                }
            }
        };

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
