using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaWarp : MonoBehaviour
{

    private Vector3 position;

    private GameObject TargetObje;

    RaycastHit hit;
    int a = 0;
    // Update is called once per frame

    public void Warp(Ray ray)
    {
        position = transform.position;
        
        if (Physics.Raycast(ray, out hit, 1000))
        {
            TargetObje = hit.collider.gameObject;
        }
        else
        {

            TargetObje = null;

        }

        transform.position = TargetObje.transform.position;
    }

    private void ActiveRay() { }
}
