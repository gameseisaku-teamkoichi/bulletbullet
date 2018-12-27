using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ChangeScene))]

public class Title : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

    public Text start;
    public Text Tutorial;
    public Text Exit;

    private enum SelectMenu
    {
        start,
        //Tutorial,
        Exit
    }

    SelectMenu Menu;

    private float OldInput;
    private float input;
    private float value = 0.00f;

	// Update is called once per frame
	void Update () {

        input = Input.GetAxis("Horizontal");

        if (input < -value && OldInput == value)
        {
            if (SelectMenu.start != Menu)
                Menu--;
        }
        else if (input > value && OldInput == value)
        {
            if (SelectMenu.Exit  != Menu)
                Menu++;
        }

        switch (Menu)
        {
            case SelectMenu.start:
                start.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                Tutorial.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                Exit.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                break;
            //case SelectMenu.Tutorial:
            //    Tutorial.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
            //    start.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            //    Exit.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
            //    break;
            case SelectMenu.Exit:
                start.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                Exit.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
                Tutorial.color = new Color(255f / 255f, 255f / 255f, 255f / 255f);
                break;
        }

        if (Input.GetButtonDown("SkillB"))
        {
            switch(Menu)
            {
                case SelectMenu.start:
                    SeceChenge.FadOut(ChangeScene.SceneState.Main2);
                    break;
                //case SelectMenu.Tutorial:
                //    //SeceChenge.FadOut(ChangeScene.SceneState.Tutorial);
                //    break;
                case SelectMenu.Exit:
                    break;
            }
        }

        OldInput = input;

        //終了する
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
