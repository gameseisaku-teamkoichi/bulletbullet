using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class GameOver : MonoBehaviour {


    public ChangeScene changeScene { get { return this.changescene ?? (this.changescene = GetComponent<ChangeScene>()); } }
    ChangeScene changescene;

    const int NowScene = 3;

	// Use this for initialization
	void Start () {
        changeScene.Initialize(NowScene);
    }
	
	// Update is called once per frame
	public void IsGameOver() {
            changeScene.SceneChange();
    }
}
