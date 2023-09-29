using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{



    void Awake() {
    if (GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1){
        Destroy(this);
    }
    else {
        DontDestroyOnLoad(this);
    }
}
}
