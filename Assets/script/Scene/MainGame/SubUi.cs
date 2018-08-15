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

    public GameObject dedUI;
    public void ChengeStatus(Status UIstatus)
    {
        switch (UIstatus)
        {
            case Status.active:
                dedUI.SetActive(true);
                break;
            case Status.notactive:
                dedUI.SetActive(false);
                break;
        }
    }
}
