using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LocalSpawnsController : MonoBehaviour
{

    GameObject GameController;
    [SerializeField] GameObject whichSpawn;
    [SerializeField] GameObject[] mazeSpawns;
    [SerializeField] string lastMazeName;
    bool canSetValues = false;
    bool canSpawn = false;

    void OnAwake()
    {
        //     if (GameController != null)
        //     {
        //         foreach (GameObject obj in mazeSpawns)
        //         {
        //             if (GameController.GetComponent<SpawnController>().LastMaze.name + "Spawn" == obj.name && canSetValues)
        //             {
        //                 canSetValues = false;
        //                 UseSpawn(obj);
        //                 StartCoroutine(ToFreeAwake());
        //             }
        //         }
        //     }


    }

    IEnumerator ToFreeAwake()
    {
        yield return new WaitForSeconds(.1f);

        canSetValues = true;
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
        mazeSpawns = GameObject.FindGameObjectsWithTag("Spawn");



        canSetValues = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (lastMazeName != GameController.GetComponent<SpawnController>().LastMazeName)
        {
            lastMazeName = GameController.GetComponent<SpawnController>().LastMazeName;
            Debug.Log(lastMazeName);
            UseSpawn(lastMazeName);
        }*/
    }

    IEnumerator WaitToSpawn(string spawnName)
    {
        while (!canSetValues)
        {
            yield return new WaitForEndOfFrame();
        }

        while(!canSpawn){
            yield return new WaitForEndOfFrame();
        }

        foreach (GameObject obj in mazeSpawns)
        {
            Debug.Log(obj.name + " " + spawnName);
            if (spawnName == obj.name)
            {
                UseSpawn(obj);
                break;
            }
        }
    }

    public void NeedSpawn(string spawnName)
    {
        canSpawn = true;
        StartCoroutine(WaitToSpawn(spawnName));
    }

    public void UseSpawn(GameObject reference)
    {
        Debug.Log("Spawning");
        SetMazeRotation(reference);
        SetPlayerPosition(reference);
    }

    public void SetPlayerPosition(GameObject reference)
    {
        Debug.Log("Setting player position after change of maze");
        GameObject playerGO = GameObject.Find("Rogerio");
        playerGO.GetComponent<PlayerController>().ChangeScenarioObj();
        playerGO.GetComponent<Transform>().position = reference.GetComponent<Transform>().position;
        canSpawn = false;
    }

    void SetMazeRotation(GameObject reference)
    {
        Debug.Log(this.gameObject.name + " Setting Maze Rotation after change: " + reference.GetComponent<Transform>().localRotation.eulerAngles.z);
        GameObject thisMaze = this.gameObject;
        Quaternion targetRotation = Quaternion.identity;
        targetRotation.eulerAngles = new Vector3(0, 0, reference.GetComponent<Transform>().localRotation.eulerAngles.z);
        thisMaze.transform.Rotate(0.0f, 0.0f, (reference.GetComponent<Transform>().localRotation.eulerAngles.z - thisMaze.GetComponent<Transform>().localRotation.eulerAngles.z), Space.Self);
        //thisMaze.GetComponent<Transform>().rotation = Quaternion.Lerp(thisMaze.GetComponent<Transform>().rotation, targetRotation, -1f);
    }
}