using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using Bullet.CharaNum;
using System;

public class CharacterStatus : MonoBehaviour
{

    private const int CharacterCount = 5;
    public int GetCharaCount()
    {
        return CharacterCount;
    }

    public enum GetSet
    {
        get,
        set,
    }

    //キャラクターが生きてるか死んでるか
    public enum CharaStatus
    {
        Live,
        die,
        Spawn
    }
    private CharaStatus[] Status = new CharaStatus[CharacterCount];
    public CharaStatus GetStatus(int num)
    {
        return Status[num];
    }
    public void SetStatus(int num, CharaStatus status)
    {
        Status[num] = status;
    }

    //キャラクターの今いるステージ
    private StageName[] CharaStageName = new StageName[CharacterCount];
    public StageName GetStageName(int num)
    {
        return CharaStageName[num];
    }
    public void SetStageName(int num, StageName stageName)
    {
        CharaStageName[num] = stageName;
    }

    //キャラクターのポジション
    private Vector3[] Position = new Vector3[CharacterCount];
    public Vector3 GetPosition(int num)
    {
        return Position[num];
    }
    public void SetPosition(int num, Vector3 position)
    {
        Position[num] = position;
    }

    //キャラクターの番号
    private CharaNum[] charaNum = new CharaNum[CharacterCount];
    public CharaNum GetcharaNum(int num)
    {
        return charaNum[num];
    }
    public void SetcharaNum(int num, CharaNum Charanum)
    {
        charaNum[num] = Charanum;
    }

    private bool flag=false;
}
