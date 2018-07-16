using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreateFlag : MonoBehaviour {

    private bool createFlag;
    private int CreateCount = 1;

    public void SetCreateFlag(bool flag)
    {
        if (createFlag != flag)
        {
            createFlag = flag;
            CreateCount = 1;
        }
        else
            CreateCount++;   
    }

    public int GetCreateCount()
    {
        return CreateCount;
    }
    public bool GetCreateFlag()
    {
        return createFlag;
    }
}
