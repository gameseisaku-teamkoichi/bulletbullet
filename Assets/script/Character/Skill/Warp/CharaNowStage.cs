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


    private StageName Player;
    private StageName FastEnemy;
    private StageName SecondEnemy;
    private StageName ThirdEnemy;
    private StageName FourthEnemy;

    CharaNum charaNum;

    private Vector3 Position;
    private bool WarpFlag;

    private int CharaCount;
    void Start()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();
    }

    //死んだきゃらのステージをリセット
    public void StageReset(int charaNum)
    {
        switch (charaNum)
        {
            case 0:
                SceneGlobalVariables.Instance.characterStatus.SetStageName(charaNum, StageName.Disabled);
                break;
            case 1:
                SceneGlobalVariables.Instance.characterStatus.SetStageName(charaNum, StageName.Disabled);
                break;
            case 2:
                SceneGlobalVariables.Instance.characterStatus.SetStageName(charaNum, StageName.Disabled);
                break;
            case 3:
                SceneGlobalVariables.Instance.characterStatus.SetStageName(charaNum, StageName.Disabled);
                break;
            case 4:
                SceneGlobalVariables.Instance.characterStatus.SetStageName(charaNum, StageName.Disabled);
                break;
        }
    }

    //ワープスキルを使った先に誰かいるか
    public bool JudgeWarp(StageName stageName)
    {
        SetStatus();
        WarpFlag = true;

        if (Player == stageName)
        {
            WarpFlag = false;
        }
        else if (FastEnemy == stageName)
        {
            WarpFlag = false;
        }
        else if (SecondEnemy == stageName)
        {
            WarpFlag = false;
        }
        else if (ThirdEnemy == stageName)
        {
            WarpFlag = false;
        }
        else if (FourthEnemy == stageName)
        {
            WarpFlag = false;
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

    private void SetStatus()
    {

        for (int i = 0; i < CharaCount; i++)
        {
            switch (i)
            {
                case 0:
                    Player = SceneGlobalVariables.Instance.characterStatus.GetStageName(i);
                    break;
                case 1:
                    FastEnemy = SceneGlobalVariables.Instance.characterStatus.GetStageName(i);
                    break;
                case 2:
                    SecondEnemy = SceneGlobalVariables.Instance.characterStatus.GetStageName(i);
                    break;
                case 3:
                    SecondEnemy = SceneGlobalVariables.Instance.characterStatus.GetStageName(i);
                    break;
                case 4:
                    SecondEnemy = SceneGlobalVariables.Instance.characterStatus.GetStageName(i);
                    break;
            }
        }
    }
}
