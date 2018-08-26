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
            //打った球を-1して打ってないことにする
            SceneGlobalVariables.Instance.gunStatus.SetBulletsNum(-1);
            Destroy(gameObject);
        }
    }
}
