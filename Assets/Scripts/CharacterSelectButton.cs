using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSelectButton : MonoBehaviour
{
    //public Animator mAnimator;
    public int id;
    public Button btn;
    public bool isLeft;
    public TextMeshProUGUI text;
    public Canvas background;
    private bool pointerEntered = false;
    private GameObject spawned;
    private GameObject spawnedSprite;
    private Strength strength;

    private void Start()
    {
        strength = ObjectStorage.strengths[0, 0];
        text.text = strength.name;
        Initialize();
    }

    private void Update()
    {
        //if (mAnimator != null) {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && pointerEntered)
        {
            //mAnimator.SetTrigger("Click");
            Debug.Log("Next");
            SwitchCharacter();
            Debug.Log(Globals.currentSelected);
        }
        //}
    }

    public void Enter()
    {
        pointerEntered = true;
    }

    public void Exit()
    {
        pointerEntered = false;
    }

    public void SwitchCharacter()
    {
        if (isLeft)
        {
            Globals.currentSelected--;
            if (Globals.currentSelected < 0)
            {
                Globals.currentSelected = 35;
            }
        }
        else
        {
            Globals.currentSelected = (Globals.currentSelected + 1) % 36;
        }
        strength = ObjectStorage.strengths[Globals.currentSelected / 9, Globals.currentSelected % 9];
        if (strength == null)
        {
            SwitchCharacter();
        } else
        {
            text.text = strength.name;
            Destroy(spawned);
            Destroy(spawnedSprite);
            Initialize();
        }
    }

    public void Initialize()
    {
        spawned = Instantiate(Globals.getCurrentModelForCharacterSelection(), new Vector3(215, 344, -30), Quaternion.Euler(new Vector3(0, -90, 0)));
        spawned.transform.localScale = new Vector3(20, 20, 20);
        spawnedSprite = Instantiate(Globals.getCurrentSpriteForCharacterSelection(), background.transform, true);
        spawnedSprite.transform.position = new Vector3(0.5691f, 5f, 0);
    }

    public void OnSwitchScene()
    {
        Globals.updateStrengths(id, strength);
        Debug.Log(Globals.finalizedStrengths);
    }

}
