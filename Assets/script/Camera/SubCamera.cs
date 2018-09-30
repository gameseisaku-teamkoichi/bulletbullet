using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class SubCamera : MonoBehaviour
{
    private int AttackChara;
    private Vector3 AttackCharaPos;
    private Vector3 value = new Vector3(0.0f, 3.5f, 0.0f);//カメラの位置の微調整
    private float Distance = 7.0f;//可変の対象とカメラの距離
    private int count;

    // Update is called once per frame
    void Update()
    {
        if (SceneGlobalVariables.Instance.characterStatus.GetStatus(AttackChara) == CharacterStatus.CharaStatus.Live)
        {
            if (AttackChara != 0)
            {
                AttackCharaPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(AttackChara);
                transform.position = AttackCharaPos + value - transform.rotation * Vector3.forward * Distance;
            }
            else
            {

            }
        }
    }

    public void Initialize()
    {
        AttackChara = SceneGlobalVariables.Instance.characterStatus.AttackChara;
        if (AttackChara != 0)
        {
            AttackCharaPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(AttackChara);
            transform.position = AttackCharaPos + value - transform.rotation * Vector3.forward * Distance;
        }
        else
        {

        }
    }
}
