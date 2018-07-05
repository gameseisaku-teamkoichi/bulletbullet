using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public ChangeScene changeScene;
    const int NowScene = 3;

    private const float TimeLimit=10.0f;
    private float NowTime;


	// Use this for initialization
	void Start () {
        NowTime = 0;
        changeScene.Initialize(NowScene);
    }
	
	// Update is called once per frame
	void Update () {

        NowTime += Time.deltaTime;

        if(NowTime>=TimeLimit)
            changeScene.SceneChange();
    }
}
