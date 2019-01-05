using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.SceneManagement;

public class E_Move : MonoBehaviour
{
    //共通
    private string currentScene;

    public Transform player;
    public Vector3 velocity;

    //敵の行動する種類
    private int type;

    //スピード
    private float regularVec;

    //プレイヤーを見つけたかどうか
    private GameObject area1;
    private GameObject area2;
    private EnemyFind find1;
    private EnemyFind find2;

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


    //Robot用
    private bool oldFlag1;
    private bool oldFlag2;

    private Transform aimR;
    private Transform lookR;



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
        currentScene = SceneManager.GetActiveScene().name;

        velocity = new Vector3(0, 0, 0);

        regularVec = 0.05f;

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


        //Robot用
        if (currentScene == "MainGame_2_Next")
        {
            area1 = GameObject.Find("FindArea1");
            area2 = GameObject.Find("FindArea2");

            find1 = area1.GetComponent<EnemyFind>();
            find2 = area2.GetComponent<EnemyFind>();


            oldFlag1 = false;
            oldFlag2 = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        switch (type)
        {
            case (int)AIType.Woman:

                WomanAI();
                break;

            case (int)AIType.Drone:

                DroneAI();
                break;


            case (int)AIType.Robot:
                if (currentScene == "MainGame_2_Next")
                {
                    Robot();
                }
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

        lookPlayer();

    }

    void Robot()
    {

        if (find1.isFind || find2.isFind)
        {
            isMove = false;
            isFire = true;

            velocity = new Vector3(0, 0, 0);
            lookPlayer();
        }

        else if (oldFlag1 == true && find1.isFind == false)
        {
            isMove = true;
            isFire = false;
            Rotation();
        }

        else if (oldFlag2 == true && find2.isFind == false)
        {
            isMove = true;
            isFire = false;
            Rotation();
        }

        else
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

        oldFlag1 = find1.isFind;
        oldFlag2 = find2.isFind;

    }

    //playerの方向を見る
    void lookPlayer()
    {
        var aim = this.player.position - this.transform.position;
        var look = Quaternion.LookRotation(aim, Vector3.up);
        transform.localRotation = look;
    }

    void lookPlayerForRobot()
    {
        aimR.position = this.player.position - this.transform.position;
        lookR.rotation = Quaternion.LookRotation(aimR.position, Vector3.up);
        transform.localRotation = lookR.rotation;
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

        if (collision.gameObject.tag == "Ground")
        {
            isUp = true;
            underPos = transform.localPosition;
            overPos = underPos + new Vector3(0, hightRange, 0);
        }
    }
}
