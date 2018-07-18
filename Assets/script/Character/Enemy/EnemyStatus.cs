using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using System;

public class EnemyStatus : MonoBehaviour
{

    CharaNum charaNume;
    StageName stageName;

    //ステージのオブジェクト
    private GameObject floor;
    private GameObject floor2;
    private GameObject floor3;
    private GameObject floor4;
    private GameObject floating;
    private GameObject floating2;
    private GameObject floating3;
    private GameObject floating4;

    private bool Flag = false;
    private int IntStageName = 0;


    public void Initialize()
    {
        charaNume = SceneGlobalVariables.Instance.enemyNumberSelect.SelectNum();

        floor = GameObject.Find("floor");
        floor2 = GameObject.Find("floor2");
        floor3 = GameObject.Find("floor3");
        floor4 = GameObject.Find("floor4");
        floating = GameObject.Find("Floatingfloor");
        floating2 = GameObject.Find("Floatingfloor2");
        floating3 = GameObject.Find("Floatingfloor3");
        floating4 = GameObject.Find("Floatingfloor4");
        SetStage();
    }

    public void SetStage()
    {
        while (!Flag)
        {
            IntStageName = UnityEngine.Random.Range(1, 9);
            stageName = (StageName)Enum.ToObject(typeof(StageName), IntStageName);
            Flag = SceneGlobalVariables.Instance.charaNowStage.JudgeWarp(stageName);
        }

        SceneGlobalVariables.Instance.charaNowStage.SetStage(stageName, charaNume);


        switch (stageName)
        {
            case StageName.floor:
                transform.position = floor.transform.position;
                break;
            case StageName.floor2:
                transform.position = floor2.transform.position;
                break;
            case StageName.floor3:
                transform.position = floor3.transform.position;
                break;
            case StageName.floor4:
                transform.position = floor4.transform.position;
                break;
            case StageName.floating:
                transform.position = floating.transform.position;
                break;
            case StageName.floating2:
                transform.position = floating2.transform.position;
                break;
            case StageName.floating3:
                transform.position = floating3.transform.position;
                break;
            case StageName.floating4:
                transform.position = floating4.transform.position;
                break;
        }

    }

    public void Reset()
    {

        SceneGlobalVariables.Instance.charaNowStage.StageReset(charaNume);
    }
}
