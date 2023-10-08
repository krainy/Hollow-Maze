using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    
    [SerializeField] GameObject miniMap;
    GameObject GameController;

    void Start(){
        if(GameController == null){
            GameController = GameObject.Find("GameController");
        }
    }

    void Update(){
        if(Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[2])){
            miniMap.SetActive(true);
        } else if (Input.GetKeyUp(GameController.GetComponent<KeyConfigController>().KeysList[2])){
            miniMap.SetActive(false);
        } 
    }

}
