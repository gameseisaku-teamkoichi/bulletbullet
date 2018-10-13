using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;

[RequireComponent(typeof(EnemyMove))]
public class EnemyMainProcess : MonoBehaviour
{
    public EnemyMove enemyMove { get { return this.move ?? (this.move = GetComponent<EnemyMove>()); } }
    EnemyMove move;

    private ForceBullet bullet;

    private int CharaCount;
    public int MyNumber;

    private bool fireFlag = false;

    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;

    // Use this for initialization
    void Start()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();

        //キャラクターごとに番号を割り振る
        //番号ごとに今いるステージ今のステータスを初期化する
        for (int i = 1; i < CharaCount; i++)
        {
            charaStatus = SceneGlobalVariables.Instance.characterStatus.GetStatus(i);
            if (charaStatus == CharacterStatus.CharaStatus.Spawn)
            {
                MyNumber = i;
                SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);

                stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
                transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                
                break;
            }
        }
        
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
        
        bullet = gameObject.GetComponentInChildren<ForceBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();

        Rotation();
        enemyMove.enemyMove();

        if (fireFlag == false)
        {
            bullet.Axis = 0f;
            fireFlag = true;
        }
        else
        {
            bullet.Axis = -1.0f;
            fireFlag = false;
        }

        bullet.StartFire();

        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

    void Rotation()
    {
        var aim = GameObject.Find("Player(Clone)").transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
    }

    public void Attack()
    {
        
    }

    private void OnCollisionEnter()
    {
        transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.die);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(MyNumber, StageName.Disabled);

        StartCoroutine(SceneGlobalVariables.Instance.characterSpawn.Spawn(MyNumber, () =>
        {
            stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
            transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
            SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);
            SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
            
        }));

        bullet = gameObject.GetComponentInChildren<ForceBullet>();
    }
}
