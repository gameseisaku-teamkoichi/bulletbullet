using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;


public class EnemyMove : MonoBehaviour {

    private GameObject EnemyStage;
    CharaNowStage enemyStage;

    StageName stageName;

    const int EnemyNum = 1;//キャラクター番号

    // Use this for initialization
    void Start () {
        EnemyStage = GameObject.Find("EnemyStage");
        enemyStage = EnemyStage.GetComponent<CharaNowStage>();

        stageName = StageName.floating;
        enemyStage.GetComponent<CharaNowStage>().GetStage(stageName, EnemyNum);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
