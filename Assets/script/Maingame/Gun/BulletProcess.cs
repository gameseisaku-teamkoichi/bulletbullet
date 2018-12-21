using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;
using DG.Tweening;

public class BulletProcess : MonoBehaviour {

    private int count;
    private int MaxCount;
    private int myNumber;

    private int DestroyTime=1;
    private int Timecount = 0;
    public int MyNumber
    {
        get { return myNumber;}
        set { myNumber = value; }
    }

    void Start()
    {
        //MaxCount = SceneGlobalVariables.Instance.gunStatus.GetBulletCount();
        //// countを目的の値に徐々に変える
        //DOTween.To(
        //    () => Timecount,         // 対象の値
        //    num => Timecount = num,  // 値の更新
        //    DestroyTime,            // 最終的な値
        //    20.0f                 // アニメーション時間
        //);
    }

    void OnCollisionEnter(Collision collision)
    {
        count++;

        if (count > MaxCount)
        {   
            Destroy(gameObject);
        }

        if(DestroyTime== Timecount)
        {
            Destroy(gameObject);
        }

        if(SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) != CharacterStatus.CharaStatus.Live)
        {
            Destroy(gameObject);
        }
    }
}
