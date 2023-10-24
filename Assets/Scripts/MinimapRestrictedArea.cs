using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRestrictedArea : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")) collider.gameObject.GetComponent<MinimapController>().EntersARestrictedArea();
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")) collider.gameObject.GetComponent<MinimapController>().ExitARestrictedArea();
    }

}
