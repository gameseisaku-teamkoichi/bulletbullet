using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class Select : MonoBehaviour
{

    public GameObject FastIcon;
    public GameObject SecondIcon;
    public GameObject ThirdIcon;
    public GameObject SelectIcon;

    public Transform FastChara;
    public Transform SecondChara;
    public Transform ThirdChara;

    private Vector3 pos;
    private Vector3 Waitpos;

    private enum Character
    {
        Fast,
        Second,
        Third
    }

    private Character character;

    public static int num;

    private float OldInput;
    private float input;
    private float value = 0.00f;
    // Use this for initialization
    void Start()
    {
        pos = FastChara.transform.position;
        Waitpos = SecondChara.transform.position;
        character = Character.Fast;
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxis("Horizontal");

        if (input < -value && OldInput == value)
        {
            if (Character.Fast != character)
                character--;
        }
        else if (input > value && OldInput == value)
        {
            if (Character.Third != character)
                character++;
        }


        switch (character)
        {
            case Character.Fast:
                FastChara.transform.position = pos;
                SecondChara.transform.position = Waitpos;
                SelectIcon.transform.position = FastIcon.transform.position;
                break;
            case Character.Second:
                SecondChara.transform.position = pos;
                FastChara.transform.position = Waitpos;
                ThirdChara.transform.position = Waitpos;
                SelectIcon.transform.position = SecondIcon.transform.position;
                break;
            case Character.Third:
                ThirdChara.transform.position = pos;
                SecondChara.transform.position = Waitpos;
                SelectIcon.transform.position = ThirdIcon.transform.position;
                break;
        }

        if (Input.GetButtonDown("SkillB"))
        {
            ChangeScene changeSece = gameObject.GetComponent<ChangeScene>();
            changeSece.Change(ChangeScene.SceneState.Main);
            num = (int)character;
        }

        OldInput = input;
    }

    public static int GetNum()
    {
        return num;
    }
}
