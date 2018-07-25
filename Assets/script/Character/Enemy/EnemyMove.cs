using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;
using System;

public class EnemyMove : MonoBehaviour
{

    CharaNum charaNum;
    StageName stageName;

    Vector3 position;

    public Vector3 Initialize(int MyNumber)
    {
        stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);

        return SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
    }
}
