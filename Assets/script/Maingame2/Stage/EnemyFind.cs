using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFind : MonoBehaviour {

    public bool isFind;
    public bool isEnemyLife1;
    public bool isEnemyLife2;
    public GameObject enemy;
    

    private void Awake()
    {
        isFind = false;
        isEnemyLife1 = true;
        isEnemyLife2 = true;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
    
        if(isEnemyLife1==false)
        {
            Destroy(gameObject);
        }

        if(isEnemyLife2==false)
        {
            Destroy(gameObject);
        }
       
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            isFind = true;
        }
    }

    


}
