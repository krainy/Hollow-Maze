using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject GameController;

    void Start(){
        if(GameController == null){
            GameController = GameObject.Find("GameController");
        }
    }

    void Update(){
        if(Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[2]) && !GameController.GetComponent<PauseController>().GameIsPaused){
            miniMap.SetActive(true);
        } else if (Input.GetKeyUp(GameController.GetComponent<KeyConfigController>().KeysList[2]) || Input.anyKeyDown){
            miniMap.SetActive(false);
        } 
    }

}
