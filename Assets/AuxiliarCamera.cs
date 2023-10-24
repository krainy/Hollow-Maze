using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuxiliarCamera : MonoBehaviour
{

    void Start(){
        this.gameObject.GetComponent<Camera>().orthographicSize = GameObject.Find("MainCamera").GetComponent<Camera>().orthographicSize + 5f;
    }
}
