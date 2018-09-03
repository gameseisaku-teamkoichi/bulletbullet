using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunStatus : MonoBehaviour {

    private float BulletPower;//弾の速さ
    private int BulletCount;//跳弾できる回数
    private int MaxBullet;//マックスの球数
    private int BulletsNum;//打った球数
    private int num;
    enum GanName
    {
        Fast,
        Second,
        Third
    }
    private GanName Name;

    void Awake()
    {
        //num=Select.GetNum();
        //Name = (GanName)Enum.ToObject(typeof(GanName), name);

        Initialize();
    }
    private void Initialize()
    {
        switch(Name)
        {
            case GanName.Fast:
                BulletCount = 5;
                MaxBullet = 5;
                BulletPower= 3000f;
                break;
            case GanName.Second:
                BulletCount = 5;
                MaxBullet = 5;
                BulletPower = 3000f;
                break;
            case GanName.Third:
                BulletCount = 5;
                MaxBullet = 5;
                BulletPower = 3000f;
                break;
            default:
                BulletCount = 5;
                MaxBullet = 5;
                BulletPower = 3000f;
                break;
        }
    }
    //最大球数
    public int GetMaxBullet()
    {
        return MaxBullet;
    }
    //跳弾回数
    public int GetBulletCount()
    {
        return BulletCount;
    }
    //弾のスピード
    public float GetBulletPower()
    {
        return BulletPower;
    }
    //残りの球数
    public int GetActiveBullet()
    {
        return MaxBullet - BulletsNum;
    }
    //打った球数
    public void SetBulletsNum(int num)
    {
        BulletsNum += num;
    }
    public void Reloading()
    {
        BulletsNum = 0;
    }

    public void ResetBulletsNum()
    {
        BulletsNum = 0;
    }
}
