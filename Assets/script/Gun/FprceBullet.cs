using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FprceBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform muzzle;

    private const int vale = 0;

    private float OldAxis;
    private float Axis;
    private float bulletPower = 1000f;

    private bool FireFlag = false;
    void Start()
    {

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);

        OldAxis = Axis;
        Axis = Input.GetAxis("Fire");

        FireFlag = FireJudge(OldAxis, Axis);

        if (Input.GetButtonDown("Fire") || FireFlag)
        {
            Shot();
        }
    }

    private bool FireJudge(float oldAxis, float axis)
    {
        bool flag = false;

        if (oldAxis == vale && axis < vale)
            flag = true;

        return flag;
    }

    private void Shot()
    {
        var bulletInstance = GameObject.Instantiate(bulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 5.0f);
    }
}
