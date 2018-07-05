using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    private GameObject ObjrctPause;

    private GameObject Pause;

    void Update () {
        if (Input.GetKeyDown("Pause"))
        {
            if (Pause == null)
            {
                Pause = GameObject.Instantiate(ObjrctPause) as GameObject;
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(Pause);
                Time.timeScale = 1f;
            }
        }
    }
}
