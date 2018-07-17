using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public LaserPoint CharacterLaser { get { return this.laserPoint ?? (this.laserPoint = GetComponent<LaserPoint>()); } }
    LaserPoint laserPoint;
    #endregion

    public GameObject Gun;

    //ワープしたかどうかのフラグ
    private bool isWarp;

    //スキル（レーザーポイント）の発動フラグ
    private bool isLaserPoint;

    // Use this for initialization
    void Start()
    {
        isWarp = false;
        isLaserPoint = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0)
        {
            return;
        }
        
        if (Input.GetButton("SkillB"))
        {
            isWarp = true;
        }

        if(Input.GetButton("SkillY"))
        {
            isLaserPoint = true;
        }

        if(Input.GetButton("Fire"))
        {
            isLaserPoint = false;
        }
        
    }

    private void FixedUpdate()
    {
        //rayを銃口の向いてるほうに銃口からまっすぐ飛ばす
        Ray ray = new Ray(Gun.transform.position, Gun.transform.forward);

        CharacterMove.CharaMove();

        if(isWarp)
        {
            CharacterWarp.Warp(ray);
            isWarp = false;
        }

        if (isLaserPoint)
        {
            CharacterLaser.Point(ray);
        }
    }
}
