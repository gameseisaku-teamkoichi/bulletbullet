using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private const float ConstDistance = 5.0f;//不変対象とカメラの距離。デフォルトの距離
    private float Distance = 5.0f;//可変の対象とカメラの距離
    private float MoveSpeed = 3.0f;//速度

    private float MiniDistance = 1.5f;//
    private float ObjectDis;

    private float input = 0.0f;//コントローラーの入力

    public Transform Player;//注視する対象

    private Quaternion MaxRange;//カメラの動ける範囲
    public Quaternion vRotation;//y
    public Quaternion hRotation;//x

    private Vector3 value = new Vector3(0.0f, 3.0f, 0.0f);//カメラの位置の微調整

    private Vector3 Position;//カメラの移動適用前のポジション
    private Quaternion Rotation;//カメラの移動適用前のローテーション

    public bool MaxFlag = false;//カメラが移動の上限下限にいるかどうか
    public bool MiniFlag = false;

    private RaycastHit hit;
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

        if (Input.GetButton("Reset"))
        {
            vRotation = Quaternion.Euler(10, 0, 0);
            hRotation = Quaternion.identity;
        }

        input = Input.GetAxis("Y");

        //カメラの移動上限を超えている && 上限の反対方向にカメラを移動しようとしている
        MaxFlag = MaxRange.x < vRotation.x && input < 0.0f;
        MiniFlag = vRotation.x < -MaxRange.x && input > 0.0f;

        if (vRotation.x < MaxRange.x && -MaxRange.x < vRotation.x)
        {
            vRotation *= Quaternion.Euler(input * MoveSpeed, 0, 0);
        }
        else if (MaxFlag || MiniFlag)
        {
            vRotation *= Quaternion.Euler(input * MoveSpeed, 0, 0);
        }
        hRotation *= Quaternion.Euler(0, Input.GetAxis("X") * MoveSpeed, 0);

        transform.rotation = hRotation * vRotation;
        Position = Player.position + value - transform.rotation * Vector3.forward * Distance;

        //Debug.DrawLine(Player.position + new Vector3(0, 2, 0), Position, Color.red, 3, false);

        //if (Physics.Linecast(Player.transform.position, Position, out hit))
        //{
        //    transform.position = Position;
        //}
        //else
        //{
        //    transform.position = Position;
        //}
    }
}
