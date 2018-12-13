using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameTime : MonoBehaviour {

    [SerializeField]
    private GameObject MaingameManager;

    private bool flag;

    public void StopGame()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
    }
}
