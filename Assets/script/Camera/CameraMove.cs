using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private float turnSpeed = 3.0f;//回転速度
    public Transform Player;

    private float distance = 5.0f;//対象とカメラの距離

    private Quaternion vRotation;
    public Quaternion hRotation;

    // Use this for initialization
    void Start()
    {
        vRotation = Quaternion.Euler(30, 0, 0);
        hRotation = Quaternion.identity;
        transform.rotation = hRotation * vRotation;

        transform.position = Player.position - transform.rotation * Vector3.forward * distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        vRotation *= Quaternion.Euler(Input.GetAxis("Y") * turnSpeed, 0, 0);

        hRotation *= Quaternion.Euler(0, Input.GetAxis("X") * turnSpeed, 0);


        transform.rotation = hRotation * vRotation;

        transform.position = Player.position + new Vector3(0, 2, 0) - transform.rotation * Vector3.forward * distance;
    }
}
