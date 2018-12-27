using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDestroy2 : MonoBehaviour {

    private GameObject area;
    private EnemyFind find;

    // Use this for initialization
    void Start()
    {

        area = GameObject.Find("FindArea2");
        find = area.GetComponent<EnemyFind>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        find.isEnemyLife2 = false;
    }
}
