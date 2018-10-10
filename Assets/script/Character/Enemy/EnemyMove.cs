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

    Vector3 position;

    private float timeOut;
    private float timeCount;

    private int directCount;

    private float speed = 6.0f;
    private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    private Vector3 TraGetPosition;
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

        //velocity +x→position.-z +z→+x -x→+z -z→-x
       
    }

    public void enemyMove()
    {
        timeCount += Time.deltaTime;

        if (timeOut < timeCount)
        {
            directCount++;
            if (directCount > 3)
                directCount = 0;
            
            switch (directCount)
            {
                //+z方向へ
                case 0:
                    velocity.x = -0.2f;
                    velocity.z = 0f;
                    break;

                //-x方向へ
                case 1:
                    velocity.x = 0f;
                    velocity.z = -0.2f;
                    break;

                //-z方向へ
                case 2:
                    velocity.x = 0.2f;
                    velocity.z = 0f;
                    break;

                //+x方向へ
                case 3:
                    velocity.x = 0f;
                    velocity.z = 0.2f;
                    break;
            }

            timeCount = 0;
        }

        TraGetPosition = transform.position;

        velocity = velocity.normalized * 4 * Time.deltaTime;

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
            
        }
    }
}
