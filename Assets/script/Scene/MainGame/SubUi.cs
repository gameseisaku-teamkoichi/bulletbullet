using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class SubUi : MonoBehaviour
{

    public enum Status
    {
        active,
        notactive
    }

    public GameObject SubCamera;
    public void ChengeStatus(Status UIstatus)
    {
        switch (UIstatus)
        {
            case Status.active:
                SubCamera.SetActive(true);
                break;
            case Status.notactive:
                SubCamera.SetActive(false);
                break;
        }
    }
}
