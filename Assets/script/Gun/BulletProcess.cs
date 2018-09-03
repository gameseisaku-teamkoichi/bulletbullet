using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class BulletProcess : MonoBehaviour {

    private int count;
    private int MaxCount;
    void Start()
    {
        MaxCount = SceneGlobalVariables.Instance.gunStatus.GetBulletCount();
    }

    void OnCollisionEnter(Collision collision)
    {
        count++;
        if (count > MaxCount)
        {   
            Destroy(gameObject);
        }
    }
}
