using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{

    public static Strength[] strengths = {null, null, null, null, null};
    // Start is called before the first frame update
    void Start()
    {

    }

    public static void updateStrengths(int id, Strength strength)
    {
        strengths[id] = strength;
    }

}
