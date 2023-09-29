using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForScenes : MonoBehaviour
{
    [SerializeField] GameObject GameController;

    void Update()
    {
        if(GameController == null){
            GameController = GameObject.Find("GameController");
        }
    }

    public static void CallScene(string sceneName){
        ButtonForScenes obj = new ButtonForScenes();


        obj.GameController.GetComponent<ScenesManager>().sceneLoadAsync(sceneName);
    }

    public static void ExitGame(){
        Application.Quit();
    }
}
