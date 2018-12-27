using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour {

    private GameObject MainCamera;
    private GameObject SubCamera1;
    private GameObject SubCamera2;

    private GameObject area1;
    private GameObject area2;
    private EnemyFind find1;
    private EnemyFind find2;


	// Use this for initialization
	void Start () {

        MainCamera = GameObject.Find("MainCamera");
        SubCamera1 = GameObject.Find("FixedCamera1");
        SubCamera2 = GameObject.Find("FixedCamera2");

        SubCamera1.SetActive(false);
        SubCamera2.SetActive(false);

        area1 = GameObject.Find("FindArea1");
        area2 = GameObject.Find("FindArea2");
        find1 = area1.GetComponent<EnemyFind>();
        find2 = area2.GetComponent<EnemyFind>();

	}
	
	// Update is called once per frame
	void Update () {

        MainCamera.SetActive(true);
        SubCamera1.SetActive(false);
        SubCamera2.SetActive(false);

        if (find1.isFind)
        {
            MainCamera.SetActive(!MainCamera.activeSelf);
            SubCamera1.SetActive(!SubCamera1.activeSelf);
        }

        if(find2.isFind)
        {
            MainCamera.SetActive(!MainCamera.activeSelf);
            SubCamera2.SetActive(!SubCamera2.activeSelf);
        }

        
		
	}
}
