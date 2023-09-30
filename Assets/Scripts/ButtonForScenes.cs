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

    
}
