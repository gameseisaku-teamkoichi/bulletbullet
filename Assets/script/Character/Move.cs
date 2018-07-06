using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Vector3 Velocity;
    private const float Speed = 8.0f;//キャラの速度

    public CameraMove Camera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void CharaMove()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        Velocity = Vector3.zero;

        Velocity.z += Input.GetAxis("Vertical");
        Velocity.x += Input.GetAxis("Horizontal");

        Velocity = Velocity.normalized * Speed * Time.deltaTime;

        transform.rotation = Camera.hRotation;

        if (Velocity.magnitude > 0)
        {
            transform.position += Camera.hRotation * Velocity;
        }

    }
}
