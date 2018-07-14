using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class CheckObstacles : MonoBehaviour
{

    private const float ConstDistance = 5.0f;//不変対象とカメラの距離。デフォルトの距離
    private float Distance = 5.0f;//可変の対象とカメラの距離
    private float MoveSpeed = 3.0f;//速度

    private Vector3 value = new Vector3(0.0f, 3.5f, 0.0f);//カメラの位置の微調整
    private Vector3 Position;//壁と当たった場所
    private Quaternion Rotation;//カメラの移動適用前のローテーション

    private bool HitFlag = false;//前フレーム壁に当たったかどうか

    private RaycastHit hit;
    // Use this for initialization
    void Start()
    {

    }

    public void Check(Vector3 CameraPosition, Vector3 PlayerPosition)
    {

        Debug.DrawLine(PlayerPosition + Vector3.up, CameraPosition, Color.red, 3, false);

        if (Physics.Linecast(PlayerPosition + Vector3.up, CameraPosition, out hit))
        {
            Position = hit.point;

            transform.position = Position;
        }
        else
        {
            transform.position = CameraPosition;

        }
    }
}
