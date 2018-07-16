using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;


public class CreateEnemy : MonoBehaviour
{

    public GameObject Enemy;

    private bool createFlag = false;

    private const float ResponseTime = 5.0f;
    private float NowTime = 0;

    private const int EnemyCount = 3;

    private int CreateCount = 0;

    // Use this for initialization
    public void Initialize()
    {

        for (int i = 0; i < EnemyCount; i++)
            Instantiate(Enemy);
    }

    // Update is called once per frame
    public void Create()
    {
        createFlag = SceneGlobalVariables.Instance.enemyCreateFlag.GetCreateFlag();
        if (createFlag)
        {
            NowTime += Time.deltaTime;
            if (ResponseTime <= NowTime)
            {
                CreateCount = SceneGlobalVariables.Instance.enemyCreateFlag.GetCreateCount();
                for (int i = 0; i < CreateCount; i++)
                {
                    Instantiate(Enemy);
                }

                createFlag = false;
                SceneGlobalVariables.Instance.enemyCreateFlag.SetCreateFlag(createFlag);
                NowTime = 0.0f;
            }
        }
    }
}
