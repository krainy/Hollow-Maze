using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRunningController : MonoBehaviour
{

    [SerializeField] string sceneName;
    [SerializeField] GameObject GameController;

    void Start()
    {
        GameController = GameObject.Find("GameController");
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            GameController.GetComponent<ScenesManager>().sceneLoadAsync(sceneName);
            
        }
    }
}
