﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 Velocity;//移動

    public Vector3 TraGetPosition;//この数値だけ変更して動いた先に地面があるか判定するのに使用
    private Quaternion TraGetRotation;
    private Vector3 value = new Vector3(1.0f, 3.0f, 0.0f);//カメラの位置の微調整

    private const float MoveSpeed = 8.0f;//キャラの移動速度
    private const float RotationSpeed = 7.0f;//キャラの速度

    public CameraMove Camera;

    RaycastHit hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void CharaMove()
    {

        TraGetPosition = transform.position;

        Velocity = Vector3.zero;
        Velocity.z += Input.GetAxis("Vertical");
        Velocity.x += Input.GetAxis("Horizontal");

        Velocity = Velocity.normalized * MoveSpeed * Time.deltaTime;

        if (Velocity.magnitude > 0.1f)
        {
            TraGetRotation = Quaternion.LookRotation(Camera.StickMove.hRotation * Velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, TraGetRotation, Time.deltaTime * RotationSpeed);

            TraGetPosition += Camera.StickMove.hRotation * Velocity;
        }

        //rayを動いた先の地面の方向に飛ばす
        Ray ray = new Ray(TraGetPosition + Vector3.up, Vector3.down);

        if (Physics.Raycast(ray, out hit, 1000))
        {

            transform.position = TraGetPosition;

        }
    }
}
