using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FprceBullet : MonoBehaviour
{
    public GameObject bulletPrefab;


    public Transform muzzle;

    private float bulletPower = 1000f;

    void Start()
    {
       
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(ray.direction);

        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    void Shot()
    {
        var bulletInstance = GameObject.Instantiate(bulletPrefab, muzzle.position, muzzle.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 5.0f);
    }
}
