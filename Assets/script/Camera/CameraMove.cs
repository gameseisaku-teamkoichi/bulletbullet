using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private const float ConstDistance = 5.0f;//不変対象とカメラの距離。デフォルトの距離
    private float Distance = 5.0f;//可変の対象とカメラの距離
    private float turnSpeed = 3.0f;//回転速度
    private float input = 0.0f;

    public Transform Player;//注視する対象

    private Quaternion MaxRange;//カメラの動ける範囲
    public Quaternion vRotation;//y
    public Quaternion hRotation;//x

    private Vector3 value = new Vector3(0.0f, 3.0f, 0.0f);//カメラの位置の微調整

    public bool MaxFlag = false;
    public bool MiniFlag = false;

    // Use this for initialization
    void Start()
    {
        MaxRange = Quaternion.Euler(90, 0, 0);
        vRotation = Quaternion.Euler(10, 0, 0);
        hRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        input = Input.GetAxis("Y");

        if(Input.GetButton("Reset"))
        {
            vRotation = Quaternion.identity;
            hRotation = Quaternion.identity;
        }
        MaxFlag = vRotation.x > MaxRange.x && input < 0.0f;
        MiniFlag = vRotation.x < -MaxRange.x && input > 0.0f;

        if (vRotation.x < MaxRange.x && vRotation.x > -MaxRange.x)
        {
            vRotation *= Quaternion.Euler(input * turnSpeed, 0, 0);
        }
        else if (MaxFlag || MiniFlag)
        {
            vRotation *= Quaternion.Euler(input * turnSpeed, 0, 0);
        }

        hRotation *= Quaternion.Euler(0, Input.GetAxis("X") * turnSpeed, 0);

        transform.rotation = hRotation * vRotation;
        transform.position = Player.position + value - transform.rotation * Vector3.forward * Distance;
    }
}
