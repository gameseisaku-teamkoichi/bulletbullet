using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class CheckObstacles : MonoBehaviour
{
    private Vector3 Position;//壁と当たった場所

    private RaycastHit hit;
    // Use this for initialization

    public void Check(Vector3 CameraPosition, Vector3 PlayerPosition)
    {


        if (Physics.Linecast(PlayerPosition + Vector3.up, CameraPosition, out hit))
        {
            Position = hit.point;

            transform.position = Position;
        }
        else
        {
            transform.position = CameraPosition;

        }
    }
}
