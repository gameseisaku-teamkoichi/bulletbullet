using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(EnemyStatus))]

public class EnemyMove : MonoBehaviour
{
    public EnemyStatus Status { get { return this.enemyStatus ?? (this.enemyStatus = GetComponent<EnemyStatus>()); } }
    EnemyStatus enemyStatus;

   private bool createFlag=true;
    // Use this for initialization
    void Start()
    {
        Status.Initialize();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter()
    {
        Status.Reset();
        SceneGlobalVariables.Instance.enemyCreateFlag.SetCreateFlag(createFlag);
        Destroy(gameObject);
    }
}
