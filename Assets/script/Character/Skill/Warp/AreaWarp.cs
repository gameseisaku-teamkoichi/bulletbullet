using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

public class AreaWarp : MonoBehaviour
{
    private GameObject TargetObje;//Rayが当たったオブジェクト

    RaycastHit hit;

    StageName stageName;
    StageName OldStageName;

    private bool WarpFlag;
    void Start()
    {

    }

    public void Warp(Ray ray)
    {

        //rayが当たっていたらそのobjを保持しする
        if (Physics.Raycast(ray, out hit, 1000))
        {
            TargetObje = hit.collider.gameObject;

            stageName = (StageName)Enum.Parse(typeof(StageName), TargetObje.name, true);

            //移動先にenemyがいるかどうか
            WarpFlag = SceneGlobalVariables.Instance.charaNowStage.JudgeWarp(stageName);

            if (WarpFlag)
            {
                transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                SceneGlobalVariables.Instance.characterStatus.SetStageName(0, stageName);

            }
        }
    }
}

