using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(EnemyMove))]
public class EnemyMainProcess : MonoBehaviour
{
    public EnemyMove enemyMove { get { return this.move ?? (this.move = GetComponent<EnemyMove>()); } }
    EnemyMove move;

    [SerializeField]
    private GameObject enemy1;

    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;

    public ForceBullet bullet;

    private Vector3 keepRotation = new Vector3(0, 0, 0);

    public int MyNumber;
    private int CharaCount;

    private float interval = 5.0f;
    private float shotInterval = 4.0f;

    private bool fireFlag = true;
    string currentScene;
    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "MainGame")
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
            shotInterval += MyNumber;
        }
        else
        {
            if (this.gameObject == enemy1)
            {
                MyNumber = 1;
            }
            else
            {
                MyNumber = 2;
            }
            SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();
        if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
        {
            enemyMove.enemyMove();
        }
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

  
    private void OnCollisionEnter()
    {
        if (currentScene == "MainGame")
        {
            if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
            {
                SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.die);
                transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
                SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);

                SceneGlobalVariables.Instance.characterStatus.SetStageName(MyNumber, StageName.Disabled);

                StartCoroutine(SceneGlobalVariables.Instance.characterSpawn.Spawn(MyNumber, () =>
                {
                    stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
                    transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                    SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);
                    SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);

                }));
            }
        }
    }
}
