using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour {

    public bool isFind;
    public bool isPlayerDie;

	// Use this for initialization
	void Start () {

        isFind = false;
        isPlayerDie = false;
	}
	
	// Update is called once per frame
	void Update () {

        //isFind = false;
        //isPlayerDie = false;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag==("Player"))
        {
            isFind = true;
            isPlayerDie = true;
        }
    }
}
