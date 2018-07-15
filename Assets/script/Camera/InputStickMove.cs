using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStickMove : MonoBehaviour {

    private Quaternion MaxRange;//カメラの動ける範囲
    private Quaternion MiniRange;

    public Quaternion vRotation;//y
    public Quaternion hRotation;//x


    private bool MaxFlag = false;//カメラが移動の上限下限にいるかどうか
    private bool MiniFlag = false;

    private float InputStickY = 0.0f;//コントローラーの入力
    private float InputStickX = 0.0f;
    private float MoveSpeed = 3.0f;//速度

    void Start()
    {
        MaxRange = Quaternion.Euler(90, 0, 0);
        MiniRange = Quaternion.Euler(-70, 0, 0);
        vRotation = Quaternion.Euler(30, 0, 0);
        hRotation = Quaternion.identity;
    }

    public void StickMove()
    {

        InputStickY = Input.GetAxis("Y");
        InputStickX = Input.GetAxis("X");

        //カメラの移動上限を超えている && 上限の反対方向にカメラを移動しようとしている
        MaxFlag = MaxRange.x < vRotation.x && InputStickY < 0.0f;
        MiniFlag = vRotation.x < MiniRange.x && InputStickY > 0.0f;

        if (vRotation.x < MaxRange.x && MiniRange.x < vRotation.x)
        {
            vRotation *= Quaternion.Euler(InputStickY * MoveSpeed, 0, 0);
        }
        else if (MaxFlag || MiniFlag)
        {
            vRotation *= Quaternion.Euler(InputStickY * MoveSpeed, 0, 0);
        }

        hRotation *= Quaternion.Euler(0, InputStickX * MoveSpeed, 0);

        transform.rotation = hRotation * vRotation;
    }

    public void CameraPosReset()
    {
            vRotation = Quaternion.Euler(10, 0, 0);
            hRotation = Quaternion.identity;
    }

}
