using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    IEnumerator LoadAsynchronously(string scene){
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while(!operation.isDone){
            Debug.Log(operation.progress);
            yield return null;
        }

    }

    [SerializeField] List<string> scenes = new List<string>();

    public void sceneLoadAsync(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    public static void ExitGame(){
        Application.Quit();
    }
}
