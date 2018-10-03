using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class BulletProcess : MonoBehaviour {

    private int count;
    private int MaxCount;
    private int myNumber;

    public int MyNumber
    {
        get { return myNumber;}
        set { myNumber = value; }
    }

    void Start()
    {
        MaxCount = SceneGlobalVariables.Instance.gunStatus.GetBulletCount();
    }

    void OnCollisionEnter(Collision collision)
    {
        count++;

        if(MyNumber==0)
        {

        }

        if (count > MaxCount)
        {   
            Destroy(gameObject);
        }
    }
}
