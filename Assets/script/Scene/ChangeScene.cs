using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour {

   public enum SceneState
    {
        title=0,
        CharaSelect,
        Tutorial,
        NextTutorial,
        Main,
        Result,
        Invalid
    }

    public void Change(SceneState sceneState)
    {
        switch (sceneState)
        {

            case SceneState.title:
                SceneManager.LoadScene("title");
                break;

            case SceneState.CharaSelect:
                SceneManager.LoadScene("CharaSelect");
                break;

            case SceneState.Tutorial:
                SceneManager.LoadScene("Tutorial");
                break;

            case SceneState.NextTutorial:
                SceneManager.LoadScene("NextTutorial");
                break;

            case SceneState.Main:
                SceneManager.LoadScene("MainGame");
                break;

            case SceneState.Result:
                SceneManager.LoadScene("Result");
                break;
        }
    }
}
