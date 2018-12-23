using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class E_Move : MonoBehaviour
{

    private bool eFind;
    public Transform player;

    private LayerMask mask;

    private Vector3 oldRotation;

    private int rotationInterval;
    private int count;

    public Vector3 velocity;
    private float regularVec;

    //最初に向いている向き
    public float defalutAngle;

    //defalutと180度回転した角度
    public float anotherAngle;

    private bool isRotation;    //キャラクターが方向転換するときに使う　デフォルトでfalse
    public bool isFowardRotation;
    public bool isMove;
    public bool isFire;

    public bool isAddVelocityX;

    enum Aspect
    {
        forward, back
    }

    // Use this for initialization
    void Start()
    {
        eFind = false;

        rotationInterval = 0;
        count = 0;

        regularVec = 0.05f;

        isRotation = false;
        isFowardRotation = false;

        isMove = false;
        isFire = false;

    }

    // Update is called once per frame
    void Update()
    {
        switch (eFind)
        {
            case false:

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
                break;

            case true:

                isMove = false;
                isFire = true;

                var aim = this.player.position - this.transform.position;
                var look = Quaternion.LookRotation(aim);
                transform.localRotation = look;
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
            if (rotationInterval > 180)
            {
                Debug.Log("true");
                isRotation = true;
                rotationInterval = 0;

                if (transform.eulerAngles.y <= defalutAngle + 5.0f && transform.eulerAngles.y >= defalutAngle - 5.0f)
                {
                    isFowardRotation = true;
                }
               
            }
        }
    }
}
