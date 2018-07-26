using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bullet.Stage;//StageName
using Bullet.CharaNum;
using BulletBullet.SceneGlobalVariables.Stage;

public class CharaNowStage : MonoBehaviour
{
    public GameObject floor;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floating;
    public GameObject floating2;
    public GameObject floating3;
    public GameObject floating4;

    CharaNum charaNum;

    private Vector3 Position;
    private bool WarpFlag;

    private int CharaCount;
    void Start()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();
    }

    //ワープスキルを使った先に誰かいるか
    public bool JudgeWarp(StageName stageName)
    {
        WarpFlag = true;
        for (int i = 0; i < CharaCount; i++)
        {
            if (SceneGlobalVariables.Instance.characterStatus.GetStageName(i) == stageName)
            {
                WarpFlag = false;
                return WarpFlag;
            }
        }
        return WarpFlag;
    }

    //実際に動かす
    public Vector3 SetPosition(StageName stageName)
    {
        switch (stageName)
        {
            case StageName.floor:
                Position = floor.transform.position;
                break;
            case StageName.floor2:
                Position = floor2.transform.position;
                break;
            case StageName.floor3:
                Position = floor3.transform.position;
                break;
            case StageName.floor4:
                Position = floor4.transform.position;
                break;
            case StageName.floating:
                Position = floating.transform.position;
                break;
            case StageName.floating2:
                Position = floating2.transform.position;
                break;
            case StageName.floating3:
                Position = floating3.transform.position;
                break;
            case StageName.floating4:
                Position = floating4.transform.position;
                break;
        }

        return Position;
    }
}
