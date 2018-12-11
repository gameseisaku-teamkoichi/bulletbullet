using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour {

   public string currentScene;
    // Use this for initialization
    void Start () {
        currentScene = SceneManager.GetActiveScene().name;
    }
	
	public string GetSceneStatas()
    {
        return currentScene;
    }
}
