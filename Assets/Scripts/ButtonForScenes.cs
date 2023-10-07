using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForScenes : MonoBehaviour
{
    [SerializeField] GameObject GameController;

    /*void Update()
    {
        if(GameController == null){
            GameController = GameObject.Find("GameController");
        }
    }*/

    public void CallScene(string sceneName){

        GameController = GameObject.Find("GameController");

        GameController.GetComponent<ScenesManager>().sceneLoadAsync(sceneName);

    }

    public void UnloadScene(string sceneName){
        GameController = GameObject.Find("GameController");

        GameController.GetComponent<ScenesManager>().sceneUnloadAsync(sceneName);
    }

    public void CallSceneAdditive(string sceneName){
        GameController = GameObject.Find("GameController");

        GameController.GetComponent<ScenesManager>().sceneLoadAdditive(sceneName);
    }

    public void ReleaseGame(){
        GameController = GameObject.Find("GameController");

        GameController.GetComponent<PauseController>().ReleaseGameByChangeScene();
    }

    
}
