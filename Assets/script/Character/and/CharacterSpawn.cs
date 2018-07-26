using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;
using System;
using Bullet.CharaNum;
using Bullet.Stage;

public class CharacterSpawn : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Player;

    private const float ResponseTime = 5.0f;//リスポーン時間
    private float[] NowTime;

    private int CharaCount;
    private int[] Stage = new int[5] { 1, 2, 4, 7, 8 };//初期スポーン位置
    private int StageNum;

    private bool SetStageFlag;
    CharacterStatus.CharaStatus[] Status;

    // Use this for initialization
    public void Initialize()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();
        NowTime = new float[CharaCount];
        Status = new CharacterStatus.CharaStatus[CharaCount];

        //プレイヤーステータス初期化
        SceneGlobalVariables.Instance.characterStatus.SetcharaNum(0, CharaNum.Player);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(0, (StageName)Enum.ToObject(typeof(StageName), Stage[0]));
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.Live);
        Instantiate(Player);

        //enemyすてーたす初期化
        for (int i = 1; i < CharaCount; i++)
            SceneGlobalVariables.Instance.characterStatus.SetStatus(i, CharacterStatus.CharaStatus.Spawn);

        for (int i = 1; i < CharaCount; i++)
        {
            //enemy生成
            SceneGlobalVariables.Instance.characterStatus.SetcharaNum(i, (CharaNum)Enum.ToObject(typeof(CharaNum), i));
            SceneGlobalVariables.Instance.characterStatus.SetStageName(i, (StageName)Enum.ToObject(typeof(StageName), Stage[i]));
            Instantiate(Enemy);
        }
    }

    // Update is called once per frame
    public void Spawn()
    {
        for (int i = 0; i < CharaCount; i++)
        {
            Status[i] = SceneGlobalVariables.Instance.characterStatus.GetStatus(i);
            if (Status[i] == CharacterStatus.CharaStatus.die)
            {
                NowTime[i] += Time.deltaTime;
                Debug.Log(NowTime[i]);
            }

            if (NowTime[i] > ResponseTime)
            {
                NowTime[i] = 0;
                SelectStage(i);

                if (i == 0)
                    Instantiate(Player);
                else
                    Instantiate(Enemy);
            }
        }
    }

    private void SelectStage(int num)
    {
        SetStageFlag = false;
        while (!SetStageFlag)
        {
            StageNum = UnityEngine.Random.Range(1, 9);
            Debug.Log(StageNum);
            SetStageFlag = SceneGlobalVariables.Instance.charaNowStage.JudgeWarp((StageName)Enum.ToObject(typeof(StageName), StageNum));
        }

        SceneGlobalVariables.Instance.characterStatus.SetStageName(num, (StageName)Enum.ToObject(typeof(StageName), StageNum));
        SceneGlobalVariables.Instance.characterStatus.SetStatus(num, CharacterStatus.CharaStatus.Spawn);
    }
}
