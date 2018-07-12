using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ChangeScene))]

public class Title : MonoBehaviour {

    public ChangeScene SeceChenge { get { return this.chengeSece ?? (this.chengeSece = GetComponent<ChangeScene>()); } }
    ChangeScene chengeSece;

    // Use this for initialization
    void Start () {
        SeceChenge.GetNowScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SkillB"))
            SeceChenge.Change();
    }
}
