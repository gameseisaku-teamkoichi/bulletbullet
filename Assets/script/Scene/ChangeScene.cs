using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour {

    enum SceneState
    {
        title=0,
        Tutorial,
        NextTutorial,
        Main,
        Result,
        Invalid
    }
    SceneState sceneState;

    private int SceneIndex;
    
    public void GetNowScene()
    {
        SceneIndex= SceneManager.GetActiveScene().buildIndex;
        sceneState = (SceneState)Enum.ToObject(typeof(SceneState), SceneIndex);
    }

    public void Change()
    {
        switch (sceneState)
        {
            case SceneState.title:
                SceneManager.LoadScene("Tutorial");

                break;
            case SceneState.Tutorial:
                SceneManager.LoadScene("NextTutorial");
                break;

            case SceneState.NextTutorial:
                SceneManager.LoadScene("MainGame");
                break;

            case SceneState.Main:
                SceneManager.LoadScene("Result");
                break;

            case SceneState.Result:
                SceneManager.LoadScene("Title");
                break;
        }
    }
}
