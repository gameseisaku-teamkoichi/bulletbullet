using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ChangeScene))]

public class GameOver : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

    private string currentScene;

	// Update is called once per frame
	public void IsGameOver(bool isTimeOver) {

        currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "MainGame_2")
        {
            if (isTimeOver)
            {
                SeceChenge.FadOut(ChangeScene.SceneState.Result);
            }
            else
            {
                SeceChenge.FadOut(ChangeScene.SceneState.Main2Next);
            }
        }

        else if (currentScene == "MainGame_2_Next")
        {
            SeceChenge.FadOut(ChangeScene.SceneState.Result);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsGameOver(false);
        }
    }
}
