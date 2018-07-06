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
    StageName OldstageName;
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

        if (OldstageName != stageName)
        {
            Debug.Log(OldstageName);
            Debug.Log(stageName);
            
            OldstageName = stageName;

            switch (stageName)
            {
                case StageName.floor:
                    transform.position = Floor.transform.position;
                    break;
                case StageName.floor2:
                    transform.position = Floor2.transform.position;
                    break;
                case StageName.floor3:
                    transform.position = Floor3.transform.position;
                    break;
                case StageName.floor4:
                    transform.position = Floor4.transform.position;
                    break;
                case StageName.floating:
                    transform.position = floating.transform.position;
                    break;
                case StageName.floating2:
                    transform.position = floating2.transform.position;
                    break;
                case StageName.floating3:
                    transform.position = floating3.transform.position;
                    break;
                case StageName.floating4:
                    transform.position = floating4.transform.position;
                    break;
            }
        }
    }
}
