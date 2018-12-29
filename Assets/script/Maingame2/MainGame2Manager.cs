using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameOver))]
[RequireComponent(typeof(PauseScript))]
[RequireComponent(typeof(SubUi))]

public class MainGame2Manager : MonoBehaviour {

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
    private Text timerText;

    private Text countdownText;
    private int minute;
    private int seconds;
    private int TimeLimit_minute;
    private int TimeLimit_seconds;
    private const float TimeLimit = 179.0f;//制限時間
    private float NowTime;

    public static int Score;
    private bool Endflag;

    private float StartCount = 3.0f;
    private float StartTime;
    public bool start;

    // Use this for initialization
    void Start () {

        NowTime = 0;

        TimeLimit_minute = (int)TimeLimit / 60;
        TimeLimit_seconds = (int)TimeLimit % 60;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Pause"))
        {
            Pause.DrowPause();
        }

        NowTime += Time.deltaTime;
        Cursor.lockState = CursorLockMode.Locked;

        if (NowTime >= TimeLimit)
        {
            End.IsGameOver(true);
        }

        Timer();

        //終了する
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void Timer()
    {
        minute = (int)NowTime / 60;
        seconds = (int)NowTime % 60;

        minute = TimeLimit_minute - minute;
        seconds = TimeLimit_seconds - seconds;

        if(seconds>=0)
        timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
    }
}
