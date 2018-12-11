using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.UI;

public class DrawIcon : MonoBehaviour {

    [SerializeField]
    private GameObject PlayerIcon;
    [SerializeField]
    private GameObject FastEnemyIcon;
    [SerializeField]
    private GameObject SecondEnemyIcon;
    [SerializeField]
    private GameObject ThirdEnemyIcon;
    [SerializeField]
    private GameObject FourthEnemyIcon;

    private Vector3 PlayerPos;
    private Vector3 FastEnemyPos;
    private Vector3 SecondEnemyPos;
    private Vector3 ThirdEnemyPos;
    private Vector3 FourthEnemyPos;

    private Vector3 YUp = new Vector3(0, 50, 0);
    private int CharaCount;

    // Use this for initialization
    void Start () {
        CharaCount = SceneGlobalVariables.Instance.characterStatus.GetCharaCount();
    }
	
	// Update is called once per frame
	void Update () {
        SceneGlobalVariables.Instance.stopGameTime.StopGame();
        GetPos();
        Draw();
    }

    private void GetPos()
    {
        PlayerPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(0);
        FastEnemyPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(1);
        SecondEnemyPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(2);
        ThirdEnemyPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(3);
        FourthEnemyPos = SceneGlobalVariables.Instance.characterStatus.GetPosition(4);
    }

    private void Draw()
    {
        for (int i = 0; i < CharaCount; i++)
        {
                switch(i)
                {
                    case 0:
                    PlayerPos.y = YUp.y;
                    PlayerIcon.transform.position = PlayerPos;
                        break;

                    case 1:
                    FastEnemyPos.y = YUp.y;
                    FastEnemyIcon.transform.position = FastEnemyPos;
                    break;

                    case 2:
                    SecondEnemyPos.y = YUp.y;
                    SecondEnemyIcon.transform.position = SecondEnemyPos;
                    break;

                    case 3:
                    ThirdEnemyPos.y = YUp.y;
                    ThirdEnemyIcon.transform.position = ThirdEnemyPos;
                    break;

                    case 4:
                    FourthEnemyPos.y = YUp.y;
                    FourthEnemyIcon.transform.position = FourthEnemyPos;
                    break;
                }
            }  
    }
}
