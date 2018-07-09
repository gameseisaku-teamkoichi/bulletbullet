using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AreaWarp : MonoBehaviour
{
    public GameObject Floor;
    public GameObject Floor2;
    public GameObject Floor3;
    public GameObject Floor4;
    public GameObject floating;
    public GameObject floating2;
    public GameObject floating3;
    public GameObject floating4;


    private Vector3 position;

    private GameObject TargetObje;
    private GameObject OldTargetObje;
    RaycastHit hit;

    // Update is called once per frame

    enum StageName
    {
        floor,
        floor2,
        floor3,
        floor4,
        floating,
        floating2,
        floating3,
        floating4
    }
    StageName stageName;
<<<<<<< HEAD
    StageName OldstageName;
=======
    StageName OldStageName;

>>>>>>> dev
    public void Warp(Ray ray)
    {
        position = transform.position;

        if (Physics.Raycast(ray, out hit, 10000))
        {
            TargetObje = hit.collider.gameObject;

            stageName = (StageName)Enum.Parse(typeof(StageName), TargetObje.name, true);
        }
        else
        {
            TargetObje = null;
        }

<<<<<<< HEAD
        if (OldstageName != stageName)
        {
            Debug.Log(OldstageName);
            Debug.Log(stageName);
            
            OldstageName = stageName;

=======
        if (OldStageName != stageName)
        {
            OldStageName = stageName;
>>>>>>> dev
            switch (stageName)
            {
                case StageName.floating:
                   position = floating.transform.position;
                    break;
                case StageName.floating2:
                    position = floating2.transform.position;
                    break;
                case StageName.floating3:
                    position = floating3.transform.position;
                    break;
                case StageName.floating4:
                    position = floating4.transform.position;
                    break;
                default:
                    position = hit.point;
                    break;
            }
            transform.position = position;
        }
    }
}
