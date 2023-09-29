using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    [SerializeField] PlayerLifeController playerLife;
    [SerializeField] PlayerPowerupController playerPowerUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            if(playerLife.CanTakeDamage){
                playerLife.CanTakeDamage = false;
                playerPowerUp.HasPowerUp = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player")){
            if(!playerLife.CanTakeDamage){
                playerLife.CanTakeDamage = true;
            }
        }
    }
}
