using System.Collections;
using System.Collections.Generic;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy_1;

    [SerializeField]
    private GameObject enemy_2;

    [SerializeField]
    private GameObject enemy_3;


    CharaNum charaNum;
    StageName stageName;

    private CharacterController controller;

    Vector3 position;
    private Vector3 TraGetPosition;
    private Vector3 moveDirection = Vector3.zero;
    public Vector3 velocity = Vector3.zero;

    private int directCount;
    private int provisionalValue;

    private float timeOut;
    private float timeCount;
    private float speed = 6.0f;
    private float gravity = 20.0f;
    private float movePower;

    //敵の動く向きを変えるときにtrueにする
    public bool differentMoveFlag;

    private RaycastHit hit;

    public Vector3 Initialize(int MyNumber)
    {
        stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);

        return SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
    }

    public void Start()
    {
        //controller = GetComponent<CharacterController>();

        timeOut = 1.5f;
        timeCount = 0;

        if(this.gameObject==enemy_1)
        {
            directCount = 0;
        }
        
        else if(this.gameObject==enemy_2)
        {

        }

        else if(this.gameObject==enemy_3)
        {

        }

        movePower = 10.0f;

        differentMoveFlag = false;

        //velocity +x→position.-z +z→+x -x→+z -z→-x

    }

    public void enemyMove()
    {
        //if (differentMoveFlag)
        //{
        //    provisionalValue = directCount;
        //    do
        //    {
        //        directCount = Random.Range(0, 10);
        //    } while (provisionalValue == directCount);

        //}
        switch (directCount)
        {
            //+z方向へ
            case 0:
                velocity.x = -movePower;
                velocity.z = 0f;
                break;

            //-x方向へ
            case 1:
                velocity.x = 0f;
                velocity.z = -movePower;
                break;

            //-z方向へ
            case 2:
                velocity.x = movePower;
                velocity.z = 0f;
                break;

            //+x方向へ
            case 3:
                velocity.x = 0f;
                velocity.z = movePower;
                break;

            //+x,+z方向へ
            case 4:
                velocity.x = -movePower;
                velocity.z = movePower;
                break;

            //+x,-z方向へ
            case 5:
                velocity.x = movePower;
                velocity.z = movePower;
                break;

            //-x,+z方向へ
            case 6:
                velocity.x = -movePower;
                velocity.z = -movePower;
                break;

            //-x,-z方向へ
            case 7:
                velocity.x = movePower;
                velocity.z = -movePower;
                break;

            //停止
            case 8:
                velocity.x = 0f;
                velocity.z = 0f;
                break;

            case 9:
                goto case 8;
        }

        TraGetPosition = transform.position;

        velocity = (velocity.normalized * 1 * Time.deltaTime);

        if (velocity.magnitude > 0.01f)
        {
            TraGetPosition += transform.rotation * velocity;
        }

        transform.position = TraGetPosition;
        if(directCount!=8)
        {
            differentMoveFlag = true;              //falseの時はwaitのモーション
        }
        else
        {
            differentMoveFlag = false;               //trueの時はwalkのモーション
        }

        if(directCount==8)
        {
            for(int i=270;i<=90;i-=5)
            {
                enemy_1.transform.rotation = Quaternion.Euler(0, i, 0);
            }
        }


        if(transform.position.x<=-385&&transform.position.z<=-152)
        {
            directCount = 8;
        }

        


        //rayを動いた先の地面の方向に飛ばす
        //Ray ray = new Ray(TraGetPosition + Vector3.up, Vector3.down);
        ////Rayが当たっていれば動ける
        //if (Physics.Raycast(ray, out hit, 1000))
        //{
        //    transform.position = TraGetPosition;
        //    differentMoveFlag = false;
        //}
        //else
        //{
        //    //当たっていなければ向きを変える
        //    differentMoveFlag = true;
        //}

    }
}
