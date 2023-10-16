using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] string[] scenes;

    IEnumerator UpdateTheActiveScenes()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene actualScene = SceneManager.GetSceneAt(i);
            scenes[i] = actualScene.name;
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(UpdateTheActiveScenes());

    }

    IEnumerator LoadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }


        Debug.Log("Scene: " + scene + " loaded.");
    }

    IEnumerator UnloadAsynchronously(string scene)
    {
        AsyncOperation operation = SceneManager.UnloadSceneAsync(scene);

        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }

    }

    void Awake()
    {

        if(SceneManager.sceneCount < 2){
            sceneLoadAsync("NewGameMenu");
        } else{
            SceneManager.UnloadSceneAsync("1");
        }

        //StartCoroutine(UpdateTheActiveScenes());

    }

    void Update()
    {
        Debug.Log(SceneManager.GetSceneAt(SceneManager.sceneCount - 1).name);
    }

    public void sceneLoadAsync(string sceneName)
    {
        Debug.Log("Loading scene: " + sceneName);
        StartCoroutine(LoadAsynchronously(sceneName));

    }

    public static void ExitGame()
    {
        Application.Quit();
    }

    public void sceneUnloadAsync(string sceneName)
    {
        StartCoroutine(UnloadAsynchronously(sceneName));
    }

    public static void sceneUnloadThisScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));
    }

    public void sceneLoadAdditive(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

    }
}
