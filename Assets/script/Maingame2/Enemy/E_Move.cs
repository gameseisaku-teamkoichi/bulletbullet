using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class E_Move : MonoBehaviour
{
    //共通
    public Transform player;
    public Vector3 velocity;

    //敵の行動する種類
    private int type;

    //スピード
    private float regularVec;

    //プレイヤーを見つけたかどうか
    private bool eFind;

    public bool isMove;
    public bool isFire;


    //Woman用
    private Vector3 oldRotation;

    private int rotationInterval;
    private int count;

    //最初に向いている向き
    private float defalutAngle;
    //defalutと180度回転した角度
    private float anotherAngle;

    //キャラクターが方向転換するときに使う　デフォルトでfalse
    private bool isRotation;
    public bool isFowardRotation;
    public bool isAddVelocityX;


    //Drone用
    //上がり始める位置をここで記録する
    private Vector3 underPos;
    private Vector3 overPos;

    private float hightRange;

    private bool isUp;


    enum AIType
    {
        Robot,
        Woman,
        Drone
    }

    // Use this for initialization
    void Start()
    {
        //共通
        velocity = new Vector3(0, 0, 0);

        regularVec = 0.05f;

        eFind = false;
        isMove = false;
        isFire = false;

        if (this.gameObject.tag == "Enemy")
        {
            type = (int)AIType.Robot;
        }
        else if (this.gameObject.tag == "Enemy2")
        {
            type = (int)AIType.Woman;
        }
        else if (this.gameObject.tag == "Enemy3")
        {
            type = (int)AIType.Drone;
        }


        //Woman用
        rotationInterval = 0;
        count = 0;

        defalutAngle = transform.eulerAngles.y;
        anotherAngle = defalutAngle + 180;

        isRotation = false;
        isFowardRotation = false;


        //Drone用

        hightRange = 10.0f;

        isUp = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (eFind)
        {
            case false:

                switch (type)
                {
                    case (int)AIType.Woman:

                        WomanAI();
                        break;

                    case (int)AIType.Drone:

                        DroneAI();
                        break;

                    case (int)AIType.Robot:

                        Robot();
                        break;
                }

                break;

            case true:

                isMove = false;
                isFire = true;

                lookRotation();
                break;
        }

        if (velocity.magnitude > 0.01f)
        {
            transform.position += transform.rotation * velocity;
        }

        CheckMove();


        SceneGlobalVariables.Instance.characterStatus.SetPosition(1, transform.position);
        rotationInterval++;
    }

    void WomanAI()
    {
        //回転するとき
        if (isRotation)
        {
            velocity = new Vector3(0, 0, 0);
            Rotation();
        }

        //していないとき
        else
        {
            //Xに進むとき
            if (isAddVelocityX)
            {
                velocity.x = regularVec;
                velocity.z = 0.0f;
            }

            //Zに進むとき
            else
            {
                velocity.x = 0.0f;
                velocity.z = regularVec;
            }

        }
    }

    void DroneAI()
    {
        if (isUp)
        {
            velocity.y = regularVec;

            if (transform.localPosition.y > overPos.y)
            {
                isUp = false;
            }
        }
        else
        {
            velocity.y = -regularVec;
        }

        lookRotation();

    }

    void Robot()
    {
        //回転するとき
        if (isRotation)
        {
            velocity = new Vector3(0, 0, 0);
            Rotation();
        }

        //していないとき
        else
        {
            //Xに進むとき
            if (isAddVelocityX)
            {
                velocity.x = regularVec;
                velocity.z = 0.0f;
            }

            //Zに進むとき
            else
            {
                velocity.x = 0.0f;
                velocity.z = regularVec;
            }

        }
    }

    //playerの方向を見る
    void lookRotation()
    {
        var aim = this.player.position - this.transform.position;
        var look = Quaternion.LookRotation(aim, Vector3.up);
        transform.localRotation = look;
    }

    void Rotation()
    {
        float angle;
        oldRotation = transform.eulerAngles;


        if (isFowardRotation)
        {
            angle = Mathf.LerpAngle(defalutAngle, anotherAngle, Time.time);
            transform.eulerAngles = new Vector3(0, angle, 0);
        }
        else
        {
            angle = Mathf.LerpAngle(anotherAngle, defalutAngle, Time.time);
            transform.eulerAngles = new Vector3(0, angle, 0);
        }

        if (oldRotation == transform.eulerAngles)
        {
            isRotation = false;
            isFowardRotation = false;
        }
    }

    private void CheckMove()
    {
        if (velocity.magnitude == 0.0f)
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Invisibles")
        {
            if (rotationInterval > 120)
            {
                isRotation = true;
                rotationInterval = 0;

                if (transform.eulerAngles.y <= defalutAngle + 5.0f && transform.eulerAngles.y >= defalutAngle - 5.0f)
                {
                    isFowardRotation = true;
                }

            }
        }

        if(collision.gameObject.tag=="Ground")
        {
            isUp = true;
            underPos = transform.localPosition;
            overPos = underPos + new Vector3(0, hightRange, 0);
        }
    }
}
