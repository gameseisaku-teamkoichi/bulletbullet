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
    public GameObject Gun;

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
        
        Ray ray = new Ray(Gun.transform.position, Gun.transform.forward);

        // Ray raay= Camera.main.ScreenPointToRay(Input.mousePosition)
        //Debug.DrawLine(ray.origin, ray.direction * 100, Color.red, 3, false);

        CharacterMove.CharaMove();

        if (Input.GetButton("SkillB"))
        {
            CharacterWarp.Warp(ray);
        }
    }
}
