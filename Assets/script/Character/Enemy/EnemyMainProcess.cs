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
    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;

    public ForceBullet bullet;
    
    private Vector3 keepRotation = new Vector3(0, 0, 0);

<<<<<<< HEAD
    private ForceBullet bullet;

    private int CharaCount;
=======
>>>>>>> 58ad0256957b8a490e0b5cd3ee5a5bc66dea152c
    public int MyNumber;
    private int CharaCount;

<<<<<<< HEAD
    private bool fireFlag = false;

    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;
=======
    private float interval = 5.0f;
    private float shotInterval = 4.0f;
>>>>>>> 58ad0256957b8a490e0b5cd3ee5a5bc66dea152c

    private bool fireFlag = true;
    
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
<<<<<<< HEAD
        
        bullet = gameObject.GetComponentInChildren<ForceBullet>();
=======

        bullet = gameObject.GetComponentInChildren<ForceBullet>();
        shotInterval += MyNumber;
>>>>>>> 58ad0256957b8a490e0b5cd3ee5a5bc66dea152c
    }

    // Update is called once per frame
    void Update()
    {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();

        Rotation();
        enemyMove.enemyMove();

<<<<<<< HEAD
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
=======
        if (fireFlag)
            StartCoroutine("Attack");

        Rotation();
>>>>>>> 58ad0256957b8a490e0b5cd3ee5a5bc66dea152c

        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

    void Rotation()
    {
        var aim = GameObject.Find("Player(Clone)").transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
<<<<<<< HEAD
        this.transform.localRotation = look;
    }

    public void Attack()
    {
        
=======

        bullet.muzzle.rotation = look;

        aim.y = 0;
        look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;

        
    }

    IEnumerator Attack()
    {
        if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
        {
            fireFlag = false;
            yield return new WaitForSeconds(shotInterval);
           
            bullet.Axis = -1.0f;
            bullet.StartFire();
            bullet.Axis = 0;
            bullet.StartFire();

            fireFlag = true;
        }
>>>>>>> 58ad0256957b8a490e0b5cd3ee5a5bc66dea152c
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
