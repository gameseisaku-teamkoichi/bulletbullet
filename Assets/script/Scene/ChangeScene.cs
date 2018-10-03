using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


    private Image image;

    private float FadeSpeed = 0.01f;

    private float red;
    private float green;
    private float blue;
    private float alfa;

    private bool flag = false;

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

    public void Initialize()
    {
        alfa = 0;
        image = GetComponent<Image>();
        red = image.color.r;
        green = image.color.g;
        blue = image.color.b;
    }

    public void FadOut()
    {
        alfa += FadeSpeed;
        SetAlpha();
    }

    public void FadeIn()
    {
        alfa -= FadeSpeed;
        SetAlpha();
    }

    private void SetAlpha()
    {
        image.color = new Color(red, green, blue, alfa);
    }

}
