using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    public GameObject Enemy;

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

}