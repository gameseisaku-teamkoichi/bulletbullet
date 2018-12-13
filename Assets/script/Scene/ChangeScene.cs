using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;

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

    [SerializeField]
    private CanvasGroup canvasGroup;
    [SerializeField]
    private float DurationSeconds;//フェードアウト終了時間
    public Ease EaseType;

    void start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
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



    public void FadOut(SceneState sceneState)
    {
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1.0f, DurationSeconds).SetEase(EaseType);
        DOVirtual.DelayedCall(
          DurationSeconds+0.5f,   
         () => {
             Change(sceneState);
               });
    }

    public void FadeIn()
    {
        canvasGroup.alpha = 1;
        canvasGroup.DOFade(0.0f, DurationSeconds).SetEase(EaseType);
    }
}
