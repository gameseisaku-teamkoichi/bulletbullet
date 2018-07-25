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

    private const float ResponseTime = 5.0f;

    private float NowTime = 0;

    private int CharaCount;

    private int[] Stage = new int[5] { 0, 2, 4, 7, 8 };

    StageName stagename;
    // Use this for initialization
    public void Initialize()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();

        for (int i = 0; i < CharaCount; i++)
            SceneGlobalVariables.Instance.characterStatus.SetStatus(i,CharacterStatus.CharaStatus.die);

        SceneGlobalVariables.Instance.characterStatus.SetcharaNum(0, CharaNum.Player);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(0, StageName.floor);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.Live);

        for (int i = 1; i < CharaCount; i++)
        {
            SceneGlobalVariables.Instance.characterStatus.SetcharaNum(i, (CharaNum)Enum.ToObject(typeof(CharaNum), i));
            SceneGlobalVariables.Instance.characterStatus.SetStageName(i, (StageName)Enum.ToObject(typeof(StageName), Stage[i]));
            Instantiate(Enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
