using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameOver))]
[RequireComponent(typeof(PauseScript))]

public class MainGameManager : MonoBehaviour
{
    #region
    public GameOver End { get { return this.gameOver ?? (this.gameOver = GetComponent<GameOver>()); } }
    GameOver gameOver;

    public PauseScript Pause { get { return this.pauseScript ?? (this.pauseScript = GetComponent<PauseScript>()); } }
    PauseScript pauseScript;
    #endregion

    private GameObject PauseObject;

    private const float TimeLimit = 10.0f;//制限時間
    private float NowTime;

    // Use this for initialization
    void Start()
    {
        NowTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Pause.DrowPause();
        }

        if (Time.timeScale == 0)
        {
            return;
        }


        if (NowTime >= TimeLimit)
        {
            End.IsGameOver();
        }
    }
}
