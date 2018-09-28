using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

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

    public GameObject Gun;
    public GameObject Targets;

    CharaNum charaNum;
    StageName stageName;
    Ray ray;
    public int MyNumber;

    // Use this for initialization
    void Awake()
    {
        MyNumber = 0;
        SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);

        stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
        transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);

        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        SceneGlobalVariables.Instance.stopGameTime.StopGame();

        //rayを銃口の向いてるほうに銃口からまっすぐ飛ばす
        ray = new Ray(Gun.transform.position, Gun.transform.forward);
        CharactePoint.Point(ray);
        CharacterMove.CharaMove();

        if (Input.GetButton("SkillB"))
        {
            CharacterWarp.Warp(ray);
        }
    }

    private void OnTriggerEnter()
    {
        transform.position=SceneGlobalVariables.Instance.charaNowStage.SetDedPosition();
        SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
        SceneGlobalVariables.Instance.characterStatus.SetStatus(0, CharacterStatus.CharaStatus.die);
        SceneGlobalVariables.Instance.characterStatus.SetStageName(0, StageName.Disabled);

      StartCoroutine(SceneGlobalVariables.Instance.characterSpawn.Spawn(MyNumber,()=>
      {
          stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
          transform.position = SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
          SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);
          SceneGlobalVariables.Instance.characterStatus.SetPosition(MyNumber, transform.position);
          SceneGlobalVariables.Instance.gunStatus.ResetBulletsNum();
      }));
    }
}


