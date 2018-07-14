using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(InputStickMove))]

public class CameraMove : MonoBehaviour
{
    public InputStickMove StickMove { get { return this.inputStickMove ?? (this.inputStickMove = GetComponent<InputStickMove>()); } }
    InputStickMove inputStickMove;

 
    public Quaternion vRotation;//y

    private const float ConstDistance = 5.0f;//不変対象とカメラの距離。デフォルトの距離
    private float Distance = 5.0f;//可変の対象とカメラの距離
    private float MoveSpeed = 3.0f;//速度

    public Transform Player;//注視する対象

    private Vector3 value = new Vector3(0.0f, 3.5f, 0.0f);//カメラの位置の微調整
    private Vector3 Position;//カメラの移動適用前のポジション
    private Quaternion Rotation;//カメラの移動適用前のローテーション

    private bool HitFlag = false;//前フレーム壁に当たったかどうか

    private RaycastHit hit;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();

        //かめらを初期値に戻す
        if (Input.GetButton("Reset"))
        {
            StickMove.CameraPosReset();
        }


        //スティックでカメラの移動
        StickMove.StickMove();

        transform.position = Player.position + value - transform.rotation * Vector3.forward * Distance;

        //Debug.DrawLine(Player.position + new Vector3(0, 2, 0), Position, Color.red, 3, false);

        //if (Physics.Linecast(Player.position, transform.position, out hit))
        //{

        //    Distance -= MoveSpeed * Time.deltaTime;
        //    transform.position = Player.position + value - transform.rotation * Vector3.forward * Distance;
        //}
        //else
        //{
        //    if (Distance < ConstDistance)
        //    {
        //        Distance += MoveSpeed * Time.deltaTime;
        //    }
        //    else
        //    {
        //        Distance = ConstDistance;
        //    }
        //    transform.position = Position;
        //}
    }
}
