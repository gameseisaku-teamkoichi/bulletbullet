using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    private void OnTriggerEnter(Collider collider)
    {
        GameOver End = GetComponent<GameOver>();
        End.IsGameOver();
    }
}
