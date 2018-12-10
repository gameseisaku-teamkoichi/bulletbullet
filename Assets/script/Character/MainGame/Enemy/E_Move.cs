using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Move : MonoBehaviour
{

    private Ray enemyRay;
    private LayerMask mask;

    private Vector3 oldRotation;

    private Vector3 limitMaxPosition;
    private Vector3 limitMinPosition;

    private Vector3 velocity;
    private float regularVec;
    private float minAngle;
    private float maxAngle;

    private int direction;

    private bool isRotation;    //キャラクターが方向転換するときに使う　デフォルトでfalse
    public bool isMove;

    enum Aspect
    {
        forward, back
    }

    // Use this for initialization
    void Start()
    {

        enemyRay = new Ray(transform.position, transform.forward);

        limitMaxPosition = new Vector3(-333, 0, 0);
        limitMinPosition = new Vector3(-274, 0, 0);

        velocity = new Vector3(0, 0, 0);
        regularVec = 0.1f;

        minAngle = 90.0f;
        maxAngle = 270.0f;

        direction = 0;

        isRotation = false;
        isMove = false;
    }

    // Update is called once per frame
    void Update()
    {

        if ((transform.position.x <= limitMaxPosition.x || transform.position.x >= limitMinPosition.x) && velocity.z == regularVec)
        {
            isRotation = true;
        }

        if (isRotation)
        {
            velocity = new Vector3(0, 0, 0);
            Rotation();
        }
        else
        {
            velocity.x = 0.0f;
            velocity.z = regularVec;
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

    void Rotation()
    {
        float angle;
        oldRotation = transform.eulerAngles;

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
            isRotation = false;
            if (direction == 0)
            {
                direction = 1;
            }
            else
            {
                direction = 0;
            }
        }
    }
}
