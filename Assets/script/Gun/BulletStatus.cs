using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatus : MonoBehaviour
{
    [SerializeField]
    private int MaxBullet = 5;//マックスの球数
    private int BulletsNum;//打った球数

    public int GetMaxBullet()
    {

        return MaxBullet;
    }

    public int GetBulletsNum()
    {

        return BulletsNum;
    }

    public void SetMaxBullet(int num)
    {
        BulletsNum = num;
    }

    //残りの球数
    public int GetActiveBullet()
    {

        return MaxBullet-BulletsNum;
    }

}
