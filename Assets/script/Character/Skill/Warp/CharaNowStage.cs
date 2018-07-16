using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bullet.Stage;//StageName
using Bullet.CharaNum;

public class CharaNowStage : MonoBehaviour
{
    public StageName PlayerStage;
    public StageName Enemy1Stage;
    public StageName Enemy2Stage;
    public StageName Enemy3Stage;
    public StageName Enemy4Stage;

    CharaNum charaNum;

    private bool WarpFlag;

    void Start()
    {
        PlayerStage = StageName.floor;
        SetStage(PlayerStage, 0);
    }

    //キャラクターの今いるステージ
    public void SetStage(StageName stageName, CharaNum charaNum)
    {
        switch (charaNum)
        {
            case CharaNum.Player:
                PlayerStage = stageName;
                break;
            case CharaNum.FastEnemy:
                Enemy1Stage = stageName;
                break;
            case CharaNum.SecondEnemy:
                Enemy2Stage = stageName;
                break;
            case CharaNum.ThirdEnemy:
                Enemy3Stage = stageName;
                break;
            case CharaNum.FourthEnemy:
                Enemy4Stage = stageName;
                break;
        };
    }

    //死んだ敵のステージをリセット
    public void StageReset(CharaNum charaNum)
    {
        switch (charaNum)
        {
            case CharaNum.Player:
                PlayerStage = StageName.Disabled;
                break;
            case CharaNum.FastEnemy:
                Enemy1Stage = StageName.Disabled;
                break;
            case CharaNum.SecondEnemy:
                Enemy2Stage = StageName.Disabled;
                break;
            case CharaNum.ThirdEnemy:
                Enemy3Stage = StageName.Disabled;
                break;
            case CharaNum.FourthEnemy:
                Enemy4Stage = StageName.Disabled;
                break;
        }
    }

    //ワープスキルを使った先に誰かいるか
    public bool JudgeWarp(StageName stageName)
    {
        WarpFlag = true;

        if (PlayerStage == stageName)
        {
            WarpFlag = false;
        }
        else if (Enemy1Stage == stageName)
        {
            WarpFlag = false;
        }
        else if (Enemy2Stage == stageName)
        {
            WarpFlag = false;
        }
        else if (Enemy3Stage == stageName)
        {
            WarpFlag = false;
        }
        else if (Enemy4Stage == stageName)
        {
            WarpFlag = false;
        }

        return WarpFlag;
    }
}
