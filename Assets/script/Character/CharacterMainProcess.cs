using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(AreaWarp))]

public class CharacterMainProcess : MonoBehaviour
{
    #region
    public Move CharacterMove { get { return this.move ?? (this.move = GetComponent<Move>()); } }
    Move move;

    public AreaWarp CharacterWarp { get { return this.areaWarp ?? (this.areaWarp = GetComponent<AreaWarp>()); } }
    AreaWarp areaWarp;
    #endregion

    public GameObject Gun;


    CharaNum charaNum;
    StageName stageName;


    // Use this for initialization
    void Start()
    {
        charaNum = CharaNum.Player;
        stageName = StageName.floor;
        SceneGlobalVariables.Instance.charaNowStage.SetStage(stageName,charaNum);
    }

    // Update is called once per frame
    void Update()
    {

        SceneGlobalVariables.Instance.stopGameTime.StopGame();

        //rayを銃口の向いてるほうに銃口からまっすぐ飛ばす
        Ray ray = new Ray(Gun.transform.position, Gun.transform.forward);

        CharacterMove.CharaMove();

        if (Input.GetButton("SkillB"))
        {
            CharacterWarp.Warp(ray);
        }
    }
}


