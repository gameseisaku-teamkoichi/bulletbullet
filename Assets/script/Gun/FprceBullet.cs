using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FprceBullet : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]
    private Texture2D cursor;

    public Transform muzzle;

    private const int vale = 0;
    private float OldAxis;
    private float Axis;
    private bool FireFlag = false;

    private float bulletPower = 2000f;

    void Start()
    {
        Cursor.SetCursor(cursor, new Vector2(cursor.width / 2, cursor.height / 2), CursorMode.ForceSoftware);
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
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
