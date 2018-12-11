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

    private int CharaCount;
    private int[] Stage = new int[5] { 1, 2, 4, 7, 8 };//初期スポーン位置
    private int StageNum;

    private bool SetStageFlag;
    private Vector3 Position;
    string currentScene;
    enum GanName
    {
        Fast,
        Second,
        Third
    }
    private GanName Name;
    private int num;

    public void Initialize()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();

        //プレイヤーステータス初期化
        SceneGlobalVariables.Instance.characterStatus.SetcharaNum(0, CharaNum.Player);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(0, (StageName)Enum.ToObject(typeof(StageName), Stage[0]));
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.Live);
        Instantiate(Player);

        //num=Select.GetNum();
        //Name = (GanName)Enum.ToObject(typeof(GanName), name);
        //switch (Name)
        //{
        //    case GanName.Fast:
        //        break;
        //    case GanName.Second:
        //        break;
        //    case GanName.Third:
        //        break;
        //    default:
        //        break;
        //}

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
    public IEnumerator Spawn(int num , Action action)
    {
        yield return new WaitForSeconds(ResponseTime);
        SelectStage(num);

        action();
    }

    private void SelectStage(int num)
    {
        SetStageFlag = false;
        while (!SetStageFlag)
        {
            StageNum = UnityEngine.Random.Range(1, 9);

            SetStageFlag = SceneGlobalVariables.Instance.charaNowStage.JudgeWarp((StageName)Enum.ToObject(typeof(StageName), StageNum));
        }

        SceneGlobalVariables.Instance.characterStatus.SetStageName(num, (StageName)Enum.ToObject(typeof(StageName), StageNum));
        SceneGlobalVariables.Instance.characterStatus.SetStatus(num, CharacterStatus.CharaStatus.Spawn);
    }
}
