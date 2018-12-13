using System.Collections;
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
        MaxBullet = 6;
        ActiveBullet = SceneGlobalVariables.Instance.gunStatus.GetActiveBullet();
    }
	
	// Update is called once per frame
	void Update () {
        //ActiveBullet = SceneGlobalVariables.Instance.gunStatus.GetActiveBullet();
        BulletText.text = ActiveBullet.ToString()+ "/"+MaxBullet.ToString();
    }
}
