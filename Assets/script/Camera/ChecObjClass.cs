using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecObjClass : MonoBehaviour {

    [SerializeField]
    private Vector3 FormerCameraPos;
    private Transform player;
    private RaycastHit hit;

    [SerializeField]
    private float CameraSpeed = 3.0f;

    // Use this for initialization
    void Start () {
        player = transform.root;

        FormerCameraPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {

    }
}
