using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GunStatus : MonoBehaviour {

    private GameObject Gun;//銃のオブジェクト
    private int BulletPower;//弾の速さ
    private int BulletCount;//跳弾回数

    private int GunNum;
    enum GanName
    {
        Fast,
        Second,
        Third
    }
    private GanName Name;

    public void SetEquip()
    {
        GunNum = Select.GetNum();
        Name = (GanName)Enum.ToObject(typeof(GanName), GunNum);
    }
}
