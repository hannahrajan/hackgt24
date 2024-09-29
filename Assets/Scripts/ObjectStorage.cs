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

    public GameObject woodCollider;
    public GameObject bridgeCollider;
    public GameObject plankCollider;

    private static GameObject[,] strengthsModels = new GameObject[4,5];
    private static GameObject[,] strengthsSprites = new GameObject[4, 5];
    public static string[,] strengthsNames =
    {
        {"Achiever", "Arranger", "Belief", "Consistency", "Deliberative", "Discipline", "Focus", "Responsibility", "Restorative"},
        {"Activator", "Command", "Communication", "Competition", "Maximizer", "Self-Assurance", "Significance", "Woo", "NULL"},
        {"Adaptability", "Connectedness", "Developer", "Empathy", "Harmony", "Includer", "Individualization", "Positivity", "Realtor"},
        {"Analytical", "Context", "Futuristic", "Ideation", "Input", "Intellection", "Learner", "Strategic", "NULL"}
    };

    public static int[,] colliders = {
        {2, 1, 1, 2, 0, 2, 1, 1, 2},
        {1, 1, 1, 1, 0, 2, 2, 2, -1},
        {1, 1, 1, 1, 1, 1, 2, 1, 1},
        {2, 1, 0, 0, 1, 2, 2, 2, -1}
    };

    public static string[] colliderList = new string[3];

    public static Dictionary<string, Dictionary<string, int[]>> dialogueDict = new Dictionary<string, Dictionary<string, int[]>>
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

        colliderList[0] = woodCollider.tag;
        colliderList[1] = bridgeCollider.tag;
        colliderList[2] = plankCollider.tag;

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
                Dictionary<string, int[]> dialogue = dialogueDict[name];
                strengths[y, x] = new Strength(i, name, strengthsModels[y, Globals.currentStrength], strengthsSprites[y, Globals.currentStrength], colliderList[colliders[y, Globals.currentStrength]], dialogue);
                //Debug.Log(strengths[y, x]);
            }
        }


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

