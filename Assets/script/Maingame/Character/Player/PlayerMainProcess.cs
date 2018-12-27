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

public class PlayerMainProcess : MonoBehaviour
{
    #region
    public Move CharacterMove { get { return this.move ?? (this.move = GetComponent<Move>()); } }
    Move move;

    public AreaWarp CharacterWarp { get { return this.areaWarp ?? (this.areaWarp = GetComponent<AreaWarp>()); } }
    AreaWarp areaWarp;

    public LaserPoint CharactePoint { get { return this.laserPoint ?? (this.laserPoint = GetComponent<LaserPoint>()); } }
    LaserPoint laserPoint;
    #endregion

    public enum Status
    {
        active,
        notactive
    }
    public GameObject SubCamera;
    public GameObject canvas;
    public GameObject Minimap;

    public GameObject Gun;
    private ForceBullet forceBullet;
    private GunStatus gunStatus;
    CharaNum charaNum;
    StageName stageName;
    Ray ray;
    Ray Gunray;
    public int MyNumber;
    int Hit;

    float DeathTime = 4.0f;
    float SpawnTime = 1.0f;
    string currentScene;
    Vector3 HitEnemyPos;
    float Axis;

    Vector3 pos;
    private LineRenderer la;

    private GameObject Area1;
    private GameObject Area2;
    private EnemyFind find1;
    private EnemyFind find2;

    private bool isStart;

    //エフェクト用
    public GameObject ExploadObject;

    private GameObject obj;
    private Vector3 oldPos;


    // Use this for initialization
    void Start()
    {
        la = GetComponent<LineRenderer>();
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
        gunStatus = GetComponentInChildren<GunStatus>();

        if (currentScene == "MainGame_2_Next")
        {
            Area1 = GameObject.Find("FindArea1");
            Area2 = GameObject.Find("FindArea2");
            find1 = Area1.GetComponent<EnemyFind>();
            find2 = Area2.GetComponent<EnemyFind>();

            isStart = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene == "MainGame_2_Next" && (find1.isFind || find2.isFind))
        {
            if (isStart == false)
            {
                StartCoroutine(Die());
                isStart = true;
            }
        }

        else
        {
            //SceneGlobalVariables.Instance.stopGameTime.StopGame();

            //rayを銃口の向いてるほうに銃口からまっすぐ飛ばす
            ray = new Ray(Gun.transform.position, Gun.transform.forward);

            if (Input.GetButton("Fire3"))
            {
                CharactePoint.Point(ray);
                forceBullet.Axis = Input.GetAxis("Fire");
            }
            else
            {
                la.SetPosition(0, new Vector3(1000, 1000, 1000));
                la.SetPosition(1, new Vector3(1000, 1000, 1000));
                la.SetPosition(2, new Vector3(1000, 1000, 1000));

            }
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
            forceBullet.StartFire();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (currentScene == "MainGame")
        {
            if (SceneGlobalVariables.Instance.characterStatus.GetStatus(MyNumber) == CharacterStatus.CharaStatus.Live)
            {
                Hit = GetComponent<Collider>().gameObject.GetComponent<BulletProcess>().MyNumber;
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
                   gunStatus.Reloading();
               }));
            }
        }
        else
        {
            if (collision.gameObject.tag == "Enemy2")
            {
                StartCoroutine("Die");
            }
        }
    }

    private IEnumerator Die()
    {
        //UIStatus(Status.active);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.die);
        //transform.position = SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();

        yield return new WaitForSeconds(DeathTime);
        oldPos = transform.position;
        obj = Instantiate(ExploadObject, oldPos, Quaternion.identity);
        transform.position = new Vector3(100000, 100000, 100000);

        yield return new WaitForSeconds(SpawnTime);
        Destroy(obj);
        gunStatus.Reloading();
        UIStatus(Status.notactive);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.Live);
        transform.position = SceneGlobalVariables.Instance.charaNowStage.SetSpawnPosition();
        find1.isFind = false;
        isStart = false;

    }


    public void UIStatus(Status UIstatus)
    {
        switch (UIstatus)
        {
            case Status.active:
                pos = transform.position;
                pos.y = 70;
                SubCamera.transform.position = pos;
                SubCamera.SetActive(true);
                canvas.SetActive(false);
                Minimap.SetActive(false);
                break;
            case Status.notactive:
                SubCamera.SetActive(false);
                canvas.SetActive(true);
                Minimap.SetActive(true);
                break;
        }
    }
}


