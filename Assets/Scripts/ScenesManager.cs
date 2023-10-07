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

    IEnumerator UnloadAsynchronously(string scene){
        AsyncOperation operation = SceneManager.UnloadSceneAsync(scene);

        while(!operation.isDone){
            Debug.Log(operation.progress);
            yield return null;
        }

    }

    void Awake(){
        sceneLoadAsync("NewGameMenu");
    }

    [SerializeField] List<string> scenes = new List<string>();

    public void sceneLoadAsync(string sceneName)
    {
        StartCoroutine(LoadAsynchronously(sceneName));
    }

    public static void ExitGame(){
        Application.Quit();
    }

    public void sceneUnloadAsync(string sceneName)
    {
        StartCoroutine(UnloadAsynchronously(sceneName));
    }

    public void sceneLoadAdditive(string sceneName){
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
