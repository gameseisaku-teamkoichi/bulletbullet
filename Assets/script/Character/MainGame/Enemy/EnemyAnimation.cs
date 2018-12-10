﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private Animator anim;

    public EnemyMove move { get { return this.defaltMove ?? (this.defaltMove = gameObject.GetComponentInParent<EnemyMove>()); } }
    EnemyMove defaltMove;
    public EnemyMainProcess eMain { get { return this.enemyMain ?? (this.enemyMain = gameObject.GetComponentInParent<EnemyMainProcess>()); } }
    EnemyMainProcess enemyMain;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (move.differentMoveFlag == true)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (eMain.fireFlag == false)
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }

    }
}
