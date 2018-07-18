using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

public class AreaWarp : MonoBehaviour
{
    //ワープする先のオブジェクト
    public GameObject floor;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floating;
    public GameObject floating2;
    public GameObject floating3;
    public GameObject floating4;

    //targetの方を向く
    public GameObject Target;
    private GameObject TargetObje;//Rayが当たったオブジェクト

    RaycastHit hit;

    StageName stageName;
    StageName OldStageName;

    private Vector3 position;

    private bool WarpFlag;

    Vector3 _RotAxis = Vector3.up;
    void Start()
    {

    }

    public void Warp(Ray ray)
    {
        position = transform.position;

        //rayが当たっていたらそのobjを保持しする
        if (Physics.Raycast(ray, out hit, 1000))
        {
            TargetObje = hit.collider.gameObject;

            stageName = (StageName)Enum.Parse(typeof(StageName), TargetObje.name, true);
        }
        else
        {
            TargetObje = null;
        }

        //移動先にenemyがいるかどうか
        WarpFlag = SceneGlobalVariables.Instance.charaNowStage.JudgeWarp(stageName);


        if (OldStageName != stageName && WarpFlag)
        {
            OldStageName = stageName;
            switch (stageName)
            {
                case StageName.floor:
                    position = floor.transform.position;
                    break;
                case StageName.floor2:
                    position = floor2.transform.position;
                    break;
                case StageName.floor3:
                    position = floor3.transform.position;
                    break;
                case StageName.floor4:
                    position = floor4.transform.position;
                    break;
                case StageName.floating:
                    position = floating.transform.position;
                    break;
                case StageName.floating2:
                    position = floating2.transform.position;
                    break;
                case StageName.floating3:
                    position = floating3.transform.position;
                    break;
                case StageName.floating4:
                    position = floating4.transform.position;
                    break;
            }

            SceneGlobalVariables.Instance.charaNowStage.SetStage(stageName, 0);
            transform.position = position;

            //キャラを真ん中のオブジェクトに向ける
            Vector3 direction = (Target.transform.position - this.transform.position).normalized;
            Vector3 xAxis = Vector3.Cross(_RotAxis, direction).normalized;
            Vector3 zAxis = Vector3.Cross(xAxis, _RotAxis).normalized;
            this.transform.rotation = Quaternion.LookRotation(zAxis, _RotAxis);
        }
    }
}
