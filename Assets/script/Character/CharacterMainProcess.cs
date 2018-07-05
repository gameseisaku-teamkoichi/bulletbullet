using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale == 0)
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        CharacterMove.CharaMove();

        if (Input.GetButton("SkillB"))
            CharacterWarp.Warp(ray);
    }
}
