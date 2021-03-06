﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ChangeScene))]

public class Result : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

    public GameObject Select;

    private enum SelectMenu
    { 
        Retry,
        //title,
        Exit
    }

    SelectMenu Menu;

    private float OldInput;
    private float input;
    private float value = 0.00f;

    public GameObject Retry;
    public GameObject Exit;
    void Start()
    {
        Cursor.visible = false;
        //Select.SetActive(false);
    }

    void Update()
    {
        if (Select.activeSelf)
        {
            input = Input.GetAxis("Horizontal");

            if (input < -value && OldInput == value)
            {
                if (SelectMenu.Retry != Menu)
                    Menu--;
            }
            else if (input > value && OldInput == value)
            {
                if (SelectMenu.Exit != Menu)
                    Menu++;
            }

            switch (Menu)
            {
                case SelectMenu.Retry:
                    Retry.SetActive(true);
                    Exit.SetActive(false);
                    break;
                //case SelectMenu.title:
                //    CharaSelect.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                //    Retry.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                //    Exit.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                //    break;
                case SelectMenu.Exit:
                    Retry.SetActive(false);
                    Exit.SetActive(true);
                    break;
            }

            if (Input.GetButtonDown("SkillB"))
            {
                switch (Menu)
                {
                    case SelectMenu.Retry:
                        SeceChenge.FadOut(ChangeScene.SceneState.Main2);
                        break;
                    //case SelectMenu.title:
                    //    SeceChenge.FadOut(ChangeScene.SceneState.title);
                    //    break;
                    case SelectMenu.Exit:
                        Application.Quit();
                        break;
                }
            }

            OldInput = input;
        }
    }
}
