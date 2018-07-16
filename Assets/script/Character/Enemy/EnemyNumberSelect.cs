using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.CharaNum;

public class EnemyNumberSelect : MonoBehaviour
{

    CharaNum EnemyNum = 0;
    int a;
    public CharaNum SelectNum()
    {
        if (EnemyNum == CharaNum.FourthEnemy)
            EnemyNum = CharaNum.FastEnemy;

        EnemyNum++;
        return EnemyNum;
    }
}
