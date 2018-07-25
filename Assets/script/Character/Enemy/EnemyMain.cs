using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Stage;
using BulletBullet.SceneGlobalVariables.Stage;
using Bullet.CharaNum;

[RequireComponent(typeof(EnemyMove))]
public class EnemyMain : MonoBehaviour
{
    public EnemyMove enemyMove { get { return this.move ?? (this.move = GetComponent<EnemyMove>()); } }
    EnemyMove move;

    private int CharaCount;
    private int MyNumber;

    private bool GetNumFlag=false;
    StageName stageName;
    CharacterStatus.CharaStatus charaStatus;
    // Use this for initialization
    void Start()
    {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();

        for (int i = 1; i < CharaCount; i++)
        {
            charaStatus = SceneGlobalVariables.Instance.characterStatus.GetStatus(i);
            Debug.Log(charaStatus);
            if (charaStatus == CharacterStatus.CharaStatus.die)
            {
                MyNumber = i;
                SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.Live);

                stageName = SceneGlobalVariables.Instance.characterStatus.GetStageName(MyNumber);
                transform.position=SceneGlobalVariables.Instance.charaNowStage.SetPosition(stageName);
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter()
    {
        SceneGlobalVariables.Instance.characterStatus.SetStatus(MyNumber, CharacterStatus.CharaStatus.die);
        Destroy(gameObject);
    }
}
