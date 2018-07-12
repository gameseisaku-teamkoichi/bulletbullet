using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunStatus : MonoBehaviour {

    public GameObject Gun;//銃のオブジェクト
    private int BulletPower;//弾の速さ
    private int BulletCount;//跳弾回数

    enum GanName
    {
        Fast,
        Second,
        Third
    }

    private GanName ganName;
    private GanName GetName;

    public void SetEquip(GameObject weapon)
    {
        Gun = weapon;

        GetName = (GanName)Enum.Parse(typeof(GanName), Gun.name, true);

        switch (GetName)
        {
            case GanName.Fast:
                BulletPower = 1;
                BulletCount = 1;
                break;

            case GanName.Second:
                BulletPower = 1;
                BulletCount = 1;
                break;

            case GanName.Third:
                BulletPower = 1;
                BulletCount = 1;
                break;
        }
    }
}
