using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForceBullet : MonoBehaviour
{

    [SerializeField]
    private Texture2D cursor;

    public GameObject bulletPrefab;

    public Transform muzzle;

    private const int vale = 0;
    private float Axis;
    private float OldAxis=0.0f;
    private bool FireFlag = false;

    private float bulletPower = 3000f;

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

        Axis = Input.GetAxis("Fire");
        FireFlag = FireJudge(OldAxis, Axis);

        if (Input.GetButtonDown("Fire") || FireFlag)
        {
            Fire();
        }

        OldAxis = Axis;
    }

    private bool FireJudge(float oldAxis, float axis)
    {
        bool flag = false;

        if (oldAxis == vale && axis < vale)
            flag = true;

        return flag;
    }

    private void Fire()
    {
        var bulletInstance = GameObject.Instantiate(bulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
    }
}
