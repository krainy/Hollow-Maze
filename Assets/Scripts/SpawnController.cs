using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject actualEnableMaze;
    public GameObject ActualEnableMaze
    {
        get { return actualEnableMaze; }
    }

    [SerializeField] GameObject lastMaze;
    public GameObject LastMaze
    {
        get { return lastMaze; }
    }
    [SerializeField] GameObject anotherObj;
    GameObject auxiliar;

    [SerializeField] int mazesIndex = 0;
    [SerializeField] GameObject[] usableMazes;

    void Awake()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
        //StartCoroutine(ChangeScenarioGameObject());
    }

    void Update()
    {
        if (this.gameObject.GetComponent<ScenesManager>().ActualSceneIndex > 2)
        {
            ScenarioController scenario = (ScenarioController)FindObjectOfType(typeof(ScenarioController));
            actualEnableMaze = scenario.gameObject;
            if (anotherObj != actualEnableMaze)
            {
                lastMaze = anotherObj;
                anotherObj = actualEnableMaze;
                GameObject player = GameObject.Find("Rogerio");
                player.GetComponent<PlayerController>().ScenarioObj = anotherObj;
            }

            if (lastMaze == null)
            {
                lastMaze = anotherObj;
            }
        }

    }

    public void AddUsableMaze(GameObject maze)
    {
        usableMazes = GetActualActiveMazes();
        usableMazes[mazesIndex] = maze;
        mazesIndex++;
    }

    GameObject[] GetActualActiveMazes()
    {
        GameObject[] aux = new GameObject[mazesIndex + 1];

        for (int i = 0; i < usableMazes.Length; i++)
        {
            aux[i] = usableMazes[i];
        }

        return aux;
    }

    public void SetActiveActualMaze(string objectName)
    {
        foreach (GameObject g in usableMazes)
        {
            if (g.name == objectName)
            {
                g.SetActive(true);
            }
        }
    }

    public void SpawnPlayer()
    {

    }

    public void WhichMazeEnable(GameObject gameObject)
    {
        actualEnableMaze = gameObject;
    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        //actualEnableMaze = GameObject.Find(next.name);
        //StartCoroutine(ChangeScenarioGameObject());
        ChangeScenario(next.name);
    }

    void ChangeScenario(string name)
    {


    }

    public GameObject UseMazeReference()
    {
        lastMaze = actualEnableMaze;

        return lastMaze;
    }

    public void DestroyAllMazes()
    {
        foreach (GameObject g in usableMazes)
        {
            Destroy(g);
        }
    }
}


