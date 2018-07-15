using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

public class EnemyMove : MonoBehaviour {

    StageName stageName;

    private int EnemyNum = 1;//キャラクター番号

    // Use this for initialization
    void Start () {
        //ステージの初期化
        stageName = StageName.floating;
        SceneGlobalVariables.Instance.charaNowStage.SetStage(stageName, EnemyNum);

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
