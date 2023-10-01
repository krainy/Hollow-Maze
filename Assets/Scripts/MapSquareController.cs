using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSquareController : MonoBehaviour
{
    [SerializeField] GameObject MapFog;

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            Destroy(MapFog);
        }
    }
}
