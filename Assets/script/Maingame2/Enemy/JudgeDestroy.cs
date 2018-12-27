using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDestroy : MonoBehaviour {

    private GameObject area;
    private EnemyFind find;

    // Use this for initialization
    void Start()
    {

        area = GameObject.Find("FindArea1");
        find = area.GetComponent<EnemyFind>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        find.isEnemyLife1 = false;
    }
}
