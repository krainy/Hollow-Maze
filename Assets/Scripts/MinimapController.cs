using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    
    [SerializeField] GameObject miniMap;

    void Update(){
        if(Input.GetKeyDown(KeyCode.Tab)){
            miniMap.SetActive(true);
        } else if (Input.GetKeyUp(KeyCode.Tab)){
            miniMap.SetActive(false);
        } 
    }

}
