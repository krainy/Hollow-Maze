using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] string[] scenes;
    [SerializeField] string actualSceneName;
    public string ActualSceneName
    {
        get { return actualSceneName; }
    }
    [SerializeField] int actualSceneIndex;
    public int ActualSceneIndex
    {
        get { return actualSceneIndex; }
    }

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
        SceneManager.activeSceneChanged += ChangedActiveScene;

        if (SceneManager.sceneCount < 2)
        {
            sceneLoadAsync("NewGameMenu");
        }
        else
        {
            SceneManager.UnloadSceneAsync("1");
        }

        //StartCoroutine(UpdateTheActiveScenes());

    }

    void ChangedActiveScene(Scene currentScene, Scene nextScene)
    {

        Debug.Log(nextScene.name + " Scene has been loaded.");
        actualSceneName = nextScene.name;
        actualSceneIndex = nextScene.buildIndex;

        if (nextScene.buildIndex <= 2 || nextScene.buildIndex >= 13)
        {

            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            if (playerGameObject != null)
            {
                Destroy(playerGameObject);
            }

            GameObject mainCameraObject = GameObject.Find("MainCamera");
            if (mainCameraObject != null)
            {
                Destroy(mainCameraObject);
            }

            this.gameObject.GetComponent<SpawnController>().DestroyAllMazes();

        }

        if (nextScene.name == "GameContent")
        {
            StartCoroutine(UnloadSceneAfterTime("GameContent", 1f));
        }

    }

    IEnumerator UnloadSceneAfterTime(string sceneName, float time)
    {
        yield return new WaitForSeconds(time);
        sceneUnloadAsync(sceneName);
        yield return null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            sceneLoadAsync("newGameMenu");
        }
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
