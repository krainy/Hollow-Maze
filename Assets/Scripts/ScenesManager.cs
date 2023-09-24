using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{


    [SerializeField] List<string> scenes = new List<string>();
    
    void Start()
    {

    }

    public void sceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
