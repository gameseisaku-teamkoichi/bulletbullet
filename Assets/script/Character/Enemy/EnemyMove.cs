using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;
using System;

public class EnemyMove : MonoBehaviour
{

    CharaNum charaNum;
    StageName stageName;

    private CharacterController controller;

    Vector3 position;
    private Vector3 TraGetPosition;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;

    private int directCount;

    private float timeOut;
    private float timeCount;
    private float speed = 6.0f;
    private float gravity = 20.0f;
    private float movePower;

    //敵の向きを変えるときにtrueにする
    private bool differentMoveFlag;

    private RaycastHit hit;

    public Vector3 Initialize(int MyNumber)
    {
        stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);

        return SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
    }

    public void Start()
    {
        controller = GetComponent<CharacterController>();

        velocity.x = -0.2f;
        timeOut = 1.5f;
        timeCount = 0;
        directCount = 0;

        movePower = 0.4f;

        differentMoveFlag = false;

        //velocity +x→position.-z +z→+x -x→+z -z→-x

    }

    public void enemyMove()
    {
        if (differentMoveFlag)
        {
            directCount++;
            if (directCount > 3)
                directCount = 0;
        }
        switch (directCount)
        {
            //+z方向へ
            case 0:
                velocity.x = -movePower;
                velocity.z = 0f;
                break;

            //-x方向へ
            case 1:
                velocity.x = 0f;
                velocity.z = -movePower;
                break;

            //-z方向へ
            case 2:
                velocity.x = movePower;
                velocity.z = 0f;
                break;

            //+x方向へ
            case 3:
                velocity.x = 0f;
                velocity.z = movePower;
                break;
        }

        TraGetPosition = transform.position;

        velocity = velocity.normalized * 6 * Time.deltaTime;

        if (velocity.magnitude > 0.1f)
        {
            TraGetPosition += transform.rotation * velocity;
        }

        //rayを動いた先の地面の方向に飛ばす
        Ray ray = new Ray(TraGetPosition + Vector3.up, Vector3.down);
        //Rayが当たっていれば動ける
        if (Physics.Raycast(ray, out hit, 1000))
        {
            transform.position = TraGetPosition;
            differentMoveFlag = false;
        }
        else
        {
            //当たっていなければ向きを変える
            differentMoveFlag = true;
        }
    }
}
