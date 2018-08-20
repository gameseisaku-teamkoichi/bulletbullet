using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class GameOver : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

	// Update is called once per frame
	public void IsGameOver() {
        SeceChenge.Change(ChangeScene.SceneState.Result);
    }
}
