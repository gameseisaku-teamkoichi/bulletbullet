using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 Velocity;//移動
    private Vector3 RayDirection;//rayの方向
    private Vector3 Position;//キャラの移動後のポジション

    private const float Speed = 8.0f;//キャラの速度

    public CameraMove Camera;

    RaycastHit hit;
    // Use this for initialization
    void Start()
    {
        RayDirection = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    public void CharaMove()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Position = transform.position;

        Velocity = Vector3.zero;
        Velocity.z += Input.GetAxis("Vertical");
        Velocity.x += Input.GetAxis("Horizontal");

        Velocity = Velocity.normalized * Speed * Time.deltaTime;

        Position += Camera.hRotation * Velocity;
        
        //rayを地面の方向に飛ばす
        Ray ray = new Ray(Position + new Vector3(0, 1, 0), RayDirection);
        Debug.DrawLine(ray.origin, ray.direction * 100, Color.red, 3, false);


        if (Velocity.magnitude > 0)
        {
            transform.position = Position;
        }

        transform.rotation = Camera.hRotation;
    }
}
