using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class Title : MonoBehaviour {
    public ChangeScene changeScene { get { return this.changescene ?? (this.changescene = GetComponent<ChangeScene>()); } }
    ChangeScene changescene;

    const int NowScene = 0;

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
