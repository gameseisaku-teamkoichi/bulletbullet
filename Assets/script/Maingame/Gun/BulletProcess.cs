﻿using System.Collections;
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

    public GameObject exploadObject;
    private GameObject obj;

    void Start()
    {
        MaxCount = SceneGlobalVariables.Instance.gun.GetBulletCount();
        // countを目的の値に徐々に変える
        DOTween.To(
            () => Timecount,         // 対象の値
            num => Timecount = num,  // 値の更新
            DestroyTime,            // 最終的な値
            20.0f                 // アニメーション時間
        );
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

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy3")
        {
            Destroy(collision.gameObject);
            this.transform.position = new Vector3(10000, 10000, 10000);
            StartCoroutine(Explosion(collision));

        }
    }

    private IEnumerator Explosion(Collision collision)
    {
        obj = Instantiate(exploadObject, collision.transform.position, Quaternion.identity) as GameObject;
        
        yield return new WaitForSeconds(2.0f);
        
        Destroy(obj);
        Destroy(gameObject);
    }
}
