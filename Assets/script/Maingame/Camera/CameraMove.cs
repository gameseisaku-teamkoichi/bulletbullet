using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(InputStickMove))]
[RequireComponent(typeof(CheckObstacles))]

public class CameraMove : MonoBehaviour
{
    public InputStickMove StickMove { get { return this.inputStickMove ?? (this.inputStickMove = GetComponent<InputStickMove>()); } }
    InputStickMove inputStickMove;

    public CheckObstacles CheckObj { get { return this.checkObstacles ?? (this.checkObstacles = GetComponent<CheckObstacles>()); } }
    CheckObstacles checkObstacles;

    public Transform Player;//注視する対象
    public Transform Enemy;//見つかったときに中止する対象
    private Vector3 PlayerPosition;
    private float Distance = 8.0f;//可変の対象とカメラの距離

    private Vector3 value = new Vector3(0.0f, 10.0f, 0.0f);//カメラの位置の微調整

    private Vector3 dieValue = new Vector3(0.0f, 10.0f, 10.0f);
    private Vector3 Position;//カメラの移動適用前のポジション
    private Quaternion Rotation;//カメラの移動適用前のローテーション

    private EnemyFind eFind;

    // Use this for initialization
    void Start()
    {
        eFind = GameObject.Find("FindArea").GetComponent<EnemyFind>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //ここで呼ばないとバグる
        if (Time.timeScale == 0)
        {
            return;
        }

        if (eFind.isFind)
        {
            StartCoroutine(deadCamera());
        }
        else
        {
            //かめらを初期値に戻す
            if (Input.GetButton("Reset"))
            {
                StickMove.CameraPosReset();
            }


            //スティックでカメラの移動
            StickMove.StickMove();

            Position = Player.position + value - transform.rotation * Vector3.forward * Distance;

            //カメラが壁に当たっているかどうか
            //CheckObj.Check(Position, Player.position);

            transform.position = Position;
        }


    }
    IEnumerator deadCamera()
    {
        transform.position = Player.position + dieValue - transform.rotation * Vector3.forward * Distance;
        var aim = Enemy.position - transform.position;
        var look = Quaternion.LookRotation(aim, Vector3.up);
        transform.localRotation = look;

        for (int i = 0; i < 120; i++)
        {
            transform.position += transform.forward * 0.1f;
        }
        yield return new WaitForSeconds(5.0f);
        eFind.isFind = false;
    }
}
