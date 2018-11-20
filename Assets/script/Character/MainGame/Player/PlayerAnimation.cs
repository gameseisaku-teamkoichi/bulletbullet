using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    private Animator anim;

    public ForceBullet fire { get { return this.defaltFire ?? (this.defaltFire = gameObject.GetComponentInChildren<ForceBullet>()); } }
    ForceBullet defaltFire;

    private Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;
        velocity.z += Input.GetAxis("Vertical");
        velocity.x += Input.GetAxis("Horizontal");
        
        if (fire.PFireMosionFlag)
        {
            anim.SetBool("Shoot", true);
        }
        else
        {
            anim.SetBool("Shoot", false);
        }

        if (velocity.magnitude > 0.1f)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        
    }
}
