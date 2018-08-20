using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class Title : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

   private enum SelectMenu
    {
        Tutorial,
        MainGame
    }

    SelectMenu Menu;

    private float Select;
    private float input=0.01f;
      
    // Use this for initialization
    void Start () {
        SeceChenge.GetNowScene();
    }
	
	// Update is called once per frame
	void Update () {

        Select = Input.GetAxis("Vertical");

        if (Select < -input)
        {
            Menu--;
        }
        else if (Select > input)
        {
            Menu++;
        }

        if (Input.GetButtonDown("SkillB"))
        {
            switch(Menu)
            {
                case SelectMenu.Tutorial:
                    SeceChenge.Change();
                    break;
                case SelectMenu.MainGame:
                    SeceChenge.Change();
                    break;
            }
        }
            
    }
}
