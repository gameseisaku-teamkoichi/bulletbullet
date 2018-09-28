﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;

[RequireComponent(typeof(EnemyMove))]
public class EnemyMainProcess : MonoBehaviour
{
    public EnemyMove enemyMove { get { return this.move ?? (this.move = GetComponent<EnemyMove>()); } }
    EnemyMove move;

    private int CharaCount;
    public int MyNumber;

    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;

    // Use this for initialization
    void Start()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();

        //キャラクターごとに番号を割り振る
        //番号ごとに今いるステージ今のステータスを初期化する
        for (int i = 1; i < CharaCount; i++)
        {
            charaStatus = SceneGlobalVariables.Instance.characterStatus.GetStatus(i);
            if (charaStatus == CharacterStatus.CharaStatus.Spawn)
            {
                MyNumber = i;
                SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);

                stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
                transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                break;
            }
        }
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();
        enemyMove.enemyMove();
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

    private void OnCollisionEnter()
    {
        transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.die);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(MyNumber, StageName.Disabled);

        StartCoroutine(SceneGlobalVariables.Instance.characterSpawn.Spawn(MyNumber, () =>
        {
            stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
            transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
            SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);
            SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);

        }));
    }
}
