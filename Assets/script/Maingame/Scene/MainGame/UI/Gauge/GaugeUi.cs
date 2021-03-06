﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BulletBullet.SceneGlobalVariables.Stage;

public class GaugeUi : MonoBehaviour {

    public Image MainCircle;
    public Image SubCircle;
    public Text BulletText;

    private int ActiveBullet;
    private int MaxBullet;

    void Start () {
        MaxBullet = SceneGlobalVariables.Instance.gun.GetMaxBullet();
        ActiveBullet = SceneGlobalVariables.Instance.gun.GetActiveBullet();
    }
	
	// Update is called once per frame
	void Update () {
        ActiveBullet = SceneGlobalVariables.Instance.gun.GetActiveBullet();
        BulletText.text = ActiveBullet.ToString()+ "/"+MaxBullet.ToString();
    }
}
