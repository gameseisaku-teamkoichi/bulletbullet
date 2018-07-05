using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move))]
[RequireComponent(typeof(AreaWarp))]
[RequireComponent(typeof(FprceBullet))]

public class CharacterMainProcess : MonoBehaviour
{
    #region
    public Move CharacterMove { get { return this.move ?? (this.move = GetComponent<Move>()); } }
    Move move;

    public AreaWarp CharacterWarp { get { return this.areaWarp ?? (this.areaWarp = GetComponent<AreaWarp>()); } }
    AreaWarp areaWarp;

    public FprceBullet CharacterShot { get { return this.fprceBullet ?? (this.fprceBullet = GetComponent<FprceBullet>()); } }
    FprceBullet fprceBullet;
    #endregion


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        CharacterMove.CharaMove();

        if (Input.GetButton("SkillB"))
            CharacterWarp.Warp(ray);
    }
}
