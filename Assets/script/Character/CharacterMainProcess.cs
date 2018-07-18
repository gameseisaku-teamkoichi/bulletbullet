using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(AreaWarp))]
[RequireComponent(typeof(LaserPoint))]

public class CharacterMainProcess : MonoBehaviour
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

    bool flag = false;

    CharaNum charaNum;
    StageName stageName;
    Ray ray;

    // Use this for initialization
    void Start()
    {
        charaNum = CharaNum.Player;
        stageName = StageName.floor;
        SceneGlobalVariables.Instance.charaNowStage.SetStage(stageName, charaNum);
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

        if (Input.GetButton("SkillY"))
        {
            flag = true;
        }
    }
}


