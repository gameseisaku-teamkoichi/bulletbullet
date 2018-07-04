using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

    const int NowScene = 0;

    public ChangeScene changeScene;
    // Use this for initialization
    void Start () {
        changeScene.Initialize(NowScene);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SkillB"))
            changeScene.SceneChange();
    }
}
