using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bullet.Stage;//StageName

public class CharaNowStage : MonoBehaviour
{

    public StageName Enemy1Stage;
    public StageName Enemy2Stage;
    public StageName Enemy3Stage;
    public StageName Enemy4Stage;

    enum CharaNum
    {
        Enemy1,
        Enemy2,
        Enemy3,
        Enemy4
    }
    CharaNum charaNum;

    private bool WarpFlag;

    //敵キャラクターの今いるステージ
    public void SetStage(StageName stageName, int Num)
    {
        charaNum = (CharaNum)Enum.ToObject(typeof(CharaNum), Num);

        switch (charaNum)
        {
            case CharaNum.Enemy1:
                Enemy1Stage = stageName;
                break;
            case CharaNum.Enemy2:
                Enemy2Stage = stageName;
                break;
            case CharaNum.Enemy3:
                Enemy3Stage = stageName;
                break;
            case CharaNum.Enemy4:
                Enemy4Stage = stageName;
                break;
        };
    }

    //ワープスキルを使った先に誰かいるか
    public bool JudgeWarp(StageName stageName)
    {
        WarpFlag = true;

        if (Enemy1Stage == stageName)
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

    //死んだ敵のステージをリセット
    public void StageReset(int Num)
    {
        charaNum = (CharaNum)Enum.ToObject(typeof(CharaNum), Num);
        switch (charaNum)
        {
            case CharaNum.Enemy1:
                Enemy1Stage = StageName.Disabled;
                break;
            case CharaNum.Enemy2:
                Enemy2Stage = StageName.Disabled;
                break;
            case CharaNum.Enemy3:
                Enemy3Stage = StageName.Disabled;
                break;
            case CharaNum.Enemy4:
                Enemy4Stage = StageName.Disabled;
                break;
        };
    }
}
