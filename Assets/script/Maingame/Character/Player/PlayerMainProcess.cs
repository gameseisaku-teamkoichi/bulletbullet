using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(AreaWarp))]
[RequireComponent(typeof(LaserPoint))]
[RequireComponent(typeof(GameOver))]

public class PlayerMainProcess : MonoBehaviour
{
    #region
    public Move CharacterMove { get { return this.move ?? (this.move = GetComponent<Move>()); } }
    Move move;

    public AreaWarp CharacterWarp { get { return this.areaWarp ?? (this.areaWarp = GetComponent<AreaWarp>()); } }
    AreaWarp areaWarp;

    public LaserPoint CharactePoint { get { return this.laserPoint ?? (this.laserPoint = GetComponent<LaserPoint>()); } }
    LaserPoint laserPoint;

    public GameOver End { get { return this.gameEnd ?? (this.gameEnd = GetComponent<GameOver>()); } }
    GameOver gameEnd;
    #endregion

    public GameObject Gun;
    private ForceBullet forceBullet;
    private EnemyFind eFind;
    CharaNum charaNum;
    StageName stageName;
    Ray ray;
    Ray Gunray;
    public int MyNumber;
    int Hit;

    private float oldFire;

    float SpawnTime = 5.0f;
    string currentScene;
    // Use this for initialization

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        MyNumber = 0;

        SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);

        if (currentScene == "MainGame")
        {
            stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
            transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
        }

        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);

        forceBullet = gameObject.GetComponentInChildren<ForceBullet>();
        eFind = GameObject.Find("FindArea").GetComponent<EnemyFind>();
    }

    // Update is called once per frame
    void Update()
    {

        if (eFind.isPlayerDie)      //敵に見つかったとき
        {
            transform.position = new Vector3(-256, 41.38f, -1.0f);
            StartCoroutine("Die");
        }
        else
        {
            //SceneGlobalVariables.Instance.stopGameTime.StopGame();

            //rayを銃口の向いてるほうに銃口からまっすぐ飛ばす
            ray = new Ray(Gun.transform.position, Gun.transform.forward);
            CharactePoint.Point(ray);

            if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
            {
                CharacterMove.CharaMove();
            }

            if (Input.GetButton("SkillB") && currentScene == "MainGame")
            {
                CharacterWarp.Warp(ray);
            }


            Gunray = Camera.main.ScreenPointToRay(Input.mousePosition);
            forceBullet.transform.rotation = Quaternion.LookRotation(Gunray.direction);
            oldFire = forceBullet.Axis;
            forceBullet.Axis = Input.GetAxis("Fire");

            if (oldFire != forceBullet.Axis)
            {
                forceBullet.StartFire();
            }

            if (transform.position.x > -15.0f && transform.position.x < 0.66f && transform.position.z > 0.32f && transform.position.z < 16.31f)
            {
                End.IsGameOver();
            }
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (currentScene == "MainGame")
        {
            if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
            {
                Hit = collider.gameObject.GetComponent<BulletProcess>().MyNumber;
                SceneGlobalVariables.Instance.desInfo.AttackChara = Hit;
                SceneGlobalVariables.Instance.desInfo.DesPosition = transform.position;

                SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.die);
                transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
                SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
                SceneGlobalVariables.Instance.characterStatus.SetStageName(0, StageName.Disabled);


                StartCoroutine(SceneGlobalVariables.Instance.characterSpawn.Spawn(MyNumber, () =>
               {
                   stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
                   transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                   SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);
                   SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
                   SceneGlobalVariables.Instance.gunStatus.ResetBulletsNum();
               }));
            }
        }
        
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(SpawnTime);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.die);
        //transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
        

        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.Live);
        transform.position = SceneGlobalVariables.Instance.charaNowStage.SetSpawnPosition();
        SceneGlobalVariables.Instance.gunStatus.Reloading();

        eFind.isPlayerDie = false;
    }
}


