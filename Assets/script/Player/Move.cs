using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 Velocity;
    private const float Speed = 3.0f;
    private const float applySpeed = 0.2f;
    public CameraMove refCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            Velocity.z += 1;
        if (Input.GetKey(KeyCode.A))
            Velocity.x -= 1;
        if (Input.GetKey(KeyCode.S))
            Velocity.z -= 1;
        if (Input.GetKey(KeyCode.D))
            Velocity.x += 1;
       
        Velocity = Velocity.normalized * Speed * Time.deltaTime;


        if (Velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(refCamera.hRotation * Velocity),applySpeed);

            transform.position += refCamera.hRotation * Velocity;
        }

    }
}
