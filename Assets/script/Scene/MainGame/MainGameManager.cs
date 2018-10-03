using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

[RequireComponent(typeof(GameOver))]
[RequireComponent(typeof(PauseScript))]
[RequireComponent(typeof(SubUi))]

public class MainGameManager : MonoBehaviour
{
    #region
    public GameOver End { get { return this.gameOver ?? (this.gameOver = GetComponent<GameOver>()); } }
    GameOver gameOver;

    public PauseScript Pause { get { return this.pauseScript ?? (this.pauseScript = GetComponent<PauseScript>()); } }
    PauseScript pauseScript;

    public SubUi SubUi { get { return this.subUi ?? (this.subUi = GetComponent<SubUi>()); } }
    SubUi subUi;
    #endregion

    public SubCamera subCamera;

    [SerializeField]
    private Texture2D cursor;

    CharacterStatus.CharaStatus OldPlayerStatus;

    private const float TimeLimit = 10.0f;//制限時間
    private float NowTime;

    public static int Score;
    // Use this for initialization
    void Start()
    {  
        //カーソル画像の大きさ
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);

        NowTime = 0;
        SceneGlobalVariables.Instance.characterSpawn.Initialize();
        OldPlayerStatus = CharacterStatus.CharaStatus.die;

        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //NowTime+=Time.deltaTime;

        if (Input.GetButtonDown("Pause"))
        {
            Pause.DrowPause();
            Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.Auto);
        }

        if (Time.timeScale == 0)
        {
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;

        if (NowTime >= TimeLimit)
        {

            End.IsGameOver();
        }

        if (SceneGlobalVariables.Instance.characterStatus.GetStatus(0) == CharacterStatus.CharaStatus.die)
        {
            subCamera.Initialize();
            SubUi.ChengeStatus(SubUi.Status.active);
            OldPlayerStatus = CharacterStatus.CharaStatus.die;

            Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.Auto);
        }
        else if (OldPlayerStatus == CharacterStatus.CharaStatus.die && SceneGlobalVariables.Instance.characterStatus.GetStatus(0) == CharacterStatus.CharaStatus.Live)
        {
            SubUi.ChengeStatus(SubUi.Status.notactive);
            OldPlayerStatus = CharacterStatus.CharaStatus.Live;

            Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
        }

    }
}
