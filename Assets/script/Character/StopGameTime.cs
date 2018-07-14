using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameTime : MonoBehaviour {

	public void StopGame()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
    }
}
