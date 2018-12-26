using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.SceneManagement;

public class GunStatus : MonoBehaviour
{

    private float BulletPower;//弾の速さ
    private int BulletCount;//跳弾できる回数
    private int MaxBullet;//マックスの球数
    private int BulletsNum;//打った球数
    private int num;
   
    private void Start()
    {
        //ゼロが代入されている
        //MaxBullet = SceneGlobalVariables.Instance.gun.GetMaxBullet();

        MaxBullet = 10;
        BulletsNum = 0;
    }

    //残りの球数
    public int GetActiveBullet()
    {
        SceneGlobalVariables.Instance.gun.SetActiveBullet(MaxBullet - BulletsNum);
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
        SceneGlobalVariables.Instance.gun.SetActiveBullet(MaxBullet - BulletsNum);
    }
}
