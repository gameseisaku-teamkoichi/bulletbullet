using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.SceneManagement;


public class Gun : MonoBehaviour {

    private float BulletPower;//弾の速さ
    private int BulletCount;//跳弾できる回数
    private int MaxBullet;//マックスの球数
    private int BulletsNum;//残りの球数
    private int num;
    enum GanName
    {
        Fast,
        Second,
        Third
    }
    private GanName Name;
    string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "MainGame")
        {

            //num=Select.GetNum();
            //Name = (GanName)Enum.ToObject(typeof(GanName), name);
            Initialize();
        }
        else
        {
            BulletCount = 5;
            BulletsNum = BulletCount;
            MaxBullet = 10;
            BulletPower = 3000f;
        }
    }

    private void Initialize()
    {
        switch (Name)
        {
            case GanName.Fast:
                BulletCount = 5;
                MaxBullet = 5;
                BulletPower = 3000f;
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
    public int GetActiveBullet()
    {
        return BulletsNum;
    }
    public void SetActiveBullet(int num)
    {
        BulletsNum = num;
    }

    public int GetMaxBullet()
    {
        return MaxBullet;
    }
    public void SetMaxBullet(int num)
    {
        MaxBullet = num;
    }

    public int GetBulletCount()
    {
        return BulletCount;
    }   
    //弾のスピード
    public float GetBulletPower()
    {
        return BulletPower;
    }
}
