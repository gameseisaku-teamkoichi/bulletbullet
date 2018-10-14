using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesInfo : MonoBehaviour {

    //playerが誰の攻撃で死んだか
    private int attackChara;
    public int AttackChara
    {
        get { return attackChara; }
        set { attackChara = value; }
    }
    //playerが死んだ位置
    private Vector3 desPosition;
    public Vector3 DesPosition
    {
        get { return desPosition; }
        set { desPosition = value; }
    }
}
