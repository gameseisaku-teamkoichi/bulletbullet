using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;
using System;


public enum EnemyMovement
{
    SPIN,
    CROSS,
    RANDOM,
    SYNCHRO
}

public class EnemyMove : MonoBehaviour
{

    CharaNum charaNum;
    StageName stageName;

    Vector3 position;

    private float timeOut;
    private float timeCount;

    //移動する向きを決めるカウント
    private int directCount;

    private float speed = 6.0f;
    private float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Vector3 velocity = Vector3.zero;

    private Vector3 positionMax;
    private Vector3 positionMin;

    EnemyMovement movement = EnemyMovement.CROSS;

    public Vector3 Initialize(int MyNumber)
    {
        stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);

        return SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
    }

    public void Start()
    {
        controller = GetComponent<CharacterController>();

        positionMax.x = transform.position.x + 3;
        positionMin.x = transform.position.x - 3;
        positionMax.z = transform.position.z + 3;
        positionMin.z = transform.position.z - 3;

        velocity.x = -0.2f;
        timeOut = 1.5f;
        timeCount = 0;
        directCount = 0;


        //velocity +x→position.-z +z→+x -x→+z -z→-x

    }

    public void enemyMove()
    {
        bool limitFlag = false;
        int synchroNum;

        timeCount += Time.deltaTime;

        switch ((int)movement)
        {
            //回る
            case 0:
                if (timeOut < timeCount)
                {
                    directCount++;
                    if (directCount > 3)
                        directCount = 0;

                    Movement(directCount);

                    timeCount = 0;
                }
                break;

            //十字
            case 1:
                if (transform.position.x > positionMax.x)
                    directCount = 1;
                else if (transform.position.x < positionMin.x)
                    directCount = 3;
                else if (transform.position.z > positionMax.z)
                    directCount = 2;
                else if (transform.position.z < positionMin.z)
                    directCount = 0;

                if (timeCount % 3 == 1)
                    directCount = UnityEngine.Random.Range(0, 5);

                Movement(directCount);

                break;

            //ランダム
            case 2:

                if(transform.position.x>positionMax.x||transform.position.x<positionMin.x
                    ||transform.position.z>positionMax.z||transform.position.z<positionMin.z)
                {
                    limitFlag = true;
                }

                if (timeCount % 5 == 2||limitFlag==true)
                {
                    directCount = UnityEngine.Random.Range(0, 5);
                }

                if(limitFlag==true)
                {
                    limitFlag = false;
                }

                Movement(directCount);
                
                break;

            case 3:

                synchroNum = UnityEngine.Random.Range(0, 3);

                if (synchroNum == 0)
                    goto case 0;

                else if (synchroNum == 1)
                    goto case 1;

                else if (synchroNum == 2)
                    goto case 2;

                break;

        }





        if (controller.isGrounded)
        {
            moveDirection = velocity;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Movement(int num)
    {
        switch (num)
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
    }
}
