using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Move : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy1;
    [SerializeField]
    private GameObject enemy2;

    private EnemyFind eFind;
    public Transform player;

    private Ray enemyRay;
    private LayerMask mask;

    private Vector3 oldRotation;

    public Vector3[] limitMaxPosition = new Vector3[3];
    public Vector3[] limitMinPosition = new Vector3[3];

    private Vector3 velocity;
    private float regularVec;
    private float minAngle;
    private float maxAngle;

    private int enemyNumber;
    private int direction;

    private bool[] isRotation = new bool[3];    //キャラクターが方向転換するときに使う　デフォルトでfalse
    public bool isMove;
    public bool isFire;

    enum Aspect
    {
        forward, back
    }

    // Use this for initialization
    void Start()
    {
        eFind = GameObject.Find("FindArea").GetComponent<EnemyFind>();

        enemyRay = new Ray(transform.position, transform.forward);

        //limitMaxPosition[0] = new Vector3(-333, 0, 0);
        //limitMinPosition[0] = new Vector3(-274, 0, 0);

        //limitMaxPosition[1] = new Vector3(-330, 0, 0);
        //limitMinPosition[1] = new Vector3(-292, 0, 0);

        velocity = new Vector3(0, 0, 0);
        regularVec = 0.05f;

        minAngle = 90.0f;
        maxAngle = 270.0f;

        direction = 0;

        for (int i = 0; i < isRotation.Length; i++)
        {
            isRotation[i] = false;
        }
        isMove = false;
        isFire = false;

        if (this.gameObject == enemy1)
        {
            enemyNumber = 0;
        }
        else
        {
            enemyNumber = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (eFind.isFind)
        {
            isMove = false;
            isFire = true;

            var aim = this.player.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            transform.localRotation = look;
        }
        else
        {
            switch (enemyNumber)
            {
                case 0:
                    if ((transform.position.x <= limitMaxPosition[0].x || transform.position.x >= limitMinPosition[0].x) && velocity.z == regularVec)
                    {
                        isRotation[0] = true;
                    }

                    if (isRotation[0])
                    {
                        velocity = new Vector3(0, 0, 0);
                        Rotation(0);
                    }
                    else
                    {
                        velocity.x = 0.0f;
                        velocity.z = regularVec;
                    }
                    break;

                case 1:
                    if ((transform.position.x <= limitMaxPosition[1].x || transform.position.x >= limitMinPosition[1].x) && velocity.z == regularVec)
                    {
                        isRotation[1] = true;
                    }

                    if (isRotation[1])
                    {
                        velocity = new Vector3(0, 0, 0);
                        Rotation(1);
                    }
                    else
                    {
                        velocity.x = 0.0f;
                        velocity.z = regularVec;
                    }
                    break;
            }

            if (velocity.magnitude > 0.01f)
            {
                transform.position += transform.rotation * velocity;
            }
            if (velocity.magnitude == 0.0f)
            {
                isMove = false;
            }
            else
            {
                isMove = true;
            }
        }
    }

    void Rotation(int num)
    {
        float angle;
        oldRotation = transform.eulerAngles;

        switch (num)
        {
            case 0:
                if (direction == 0)
                {
                    angle = Mathf.LerpAngle(maxAngle, minAngle, Time.time);
                    transform.eulerAngles = new Vector3(0, angle, 0);
                }
                else
                {
                    angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
                    transform.eulerAngles = new Vector3(0, angle, 0);
                }

                if (oldRotation == transform.eulerAngles)
                {
                    if (isRotation[0] == true)
                    {
                        isRotation[0] = false;
                    }
                    if (isRotation[1] == true)
                    {
                        isRotation[1] = false;
                    }

                    if (direction == 0)
                    {
                        direction = 1;
                    }
                    else
                    {
                        direction = 0;
                    }
                }
                break;

            case 1:
                goto case 0;
        }


    }
}
