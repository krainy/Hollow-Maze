using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRunningController : MonoBehaviour
{

    [SerializeField] string sceneName;
    [SerializeField] GameObject GameController;
    [SerializeField] GameObject playerGameObject;
    [SerializeField] GameObject thisMaze;
    [SerializeField] mazePlayerAre MazePlayerAre;
    enum mazePlayerAre
    {
        initial,
        fire,
        air,
        earth,
        water
    }

    void OnEnable()
    {
        if (GameController != null)
        {

            GameController.GetComponent<SpawnController>().WhichMazeEnable(this.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }

    void Start()
    {
        playerGameObject = GameObject.Find("Rogerio");
        GameController = GameObject.Find("GameController");
        thisMaze = this.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        GameController.GetComponent<SpawnController>().WhichMazeEnable(thisMaze);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            thisMaze.SetActive(false);
            GameController.GetComponent<SpawnController>().SpawnPlayer();
            GameController.GetComponent<ScenesManager>().sceneLoadAsync(sceneName);

        }
    }
}
