using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseScript : MonoBehaviour
{

    [SerializeField]
    private GameObject ObjrctPause;
    private GameObject Pause;

    public void DrowPause()
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
