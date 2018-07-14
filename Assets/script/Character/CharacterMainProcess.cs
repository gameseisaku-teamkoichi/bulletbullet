using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Use this for initialization
    void Start()
    {
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


