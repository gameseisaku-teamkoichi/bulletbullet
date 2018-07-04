using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

    const int NowScene = 0;
	// Use this for initialization
	void Start () {
        ChangeScene Change = gameObject.GetComponent<ChangeScene>();

        Change.Initialize(NowScene);
    }
	
	// Update is called once per frame
	void Update () {
        ChangeScene Change = gameObject.GetComponent<ChangeScene>();

    }
}
