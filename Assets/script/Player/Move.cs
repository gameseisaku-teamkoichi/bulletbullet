using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 Velocity;
    private const float Speed = 3.0f;
    private const float applySpeed = 0.2f;
    private float h;
    private float v;
    public CameraMove refCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Velocity = Vector3.zero;

        Velocity.z += Input.GetAxis("Vertical");
        Velocity.x += Input.GetAxis("Horizontal");

        Velocity = Velocity.normalized * Speed * Time.deltaTime;

        if (Velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(refCamera.hRotation * Velocity),applySpeed);

            transform.position += refCamera.hRotation * Velocity;
        }

    }
}
