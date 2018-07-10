using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject Player;

    public Vector3 Velocity;//移動
    private Vector3 RayDirection;//rayの方向
    private Vector3 GameObjPos;//Playerキャラクターのポジション

    private const float Speed = 8.0f;//キャラの速度

    private bool    IsMove;

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

        GameObjPos = Player.transform.position;

        Velocity = Vector3.zero;
        Velocity.z += Input.GetAxis("Vertical");
        Velocity.x += Input.GetAxis("Horizontal");

        Velocity = Velocity.normalized * Speed * Time.deltaTime;

        GameObjPos += Camera.hRotation * Velocity;

        if (Velocity.magnitude > 0)
        {
            //rayを動いた先の地面の方向に飛ばす
            Ray ray = new Ray(GameObjPos + new Vector3(0, 1, 0), RayDirection);
            //Debug.DrawLine(ray.origin, ray.direction * 100, Color.red, 3, false);

            IsMove = Physics.Raycast(ray, out hit, 1000);
        }

        //動いた後のrayが当たっていたらそれを反映
        if (IsMove)
        {   //GameObjPosを代入はｘ
            transform.position += Camera.hRotation * Velocity;
        }
        else
        {
            GameObjPos -= Camera.hRotation * Velocity;
        }

       transform.rotation = Camera.hRotation;

        IsMove = false;
    }
}
