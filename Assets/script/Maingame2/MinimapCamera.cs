using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BulletBullet.SceneGlobalVariables.Stage;

public class MinimapCamera : MonoBehaviour {

    private Vector3 pos;

    private Vector3 ConstPos=new Vector3(0.0f, 70.0f, 0.0f);
	// Use this for initialization
	void Start () {
        SetPos();
    }
	
	// Update is called once per frame
	void Update () {
        SetPos();
    }

    private void SetPos()
    {
        pos = SceneGlobalVariables.Instance.characterStatus.GetPosition(0);

        pos.y = ConstPos.y;
        transform.position = pos;
    }
}
