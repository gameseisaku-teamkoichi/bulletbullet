using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProcess : MonoBehaviour {

    private int count;
    void OnCollisionEnter(Collision collision)
    {
        count++;
        if (count >= 5)
            Destroy(gameObject);
    }

}
