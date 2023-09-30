using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    /// <summary>
    ///0 = Nenhum
    ///1 = Fogo
    ///2 = Vento
    ///3 = Agua
    ///4 = Terra
    /// </summary>
    [SerializeField] [Tooltip("0 = Nenhum 1 = Fogo 2 = Vento 3 = Agua 4 = Terra.")] int wallElement = 0;

    [SerializeField] GameObject playerObj;
    [SerializeField] ScenarioController scenario;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("weeee");
        scenario = GameObject.Find("Walls").GetComponent<ScenarioController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            if(playerObj.GetComponent<PlayerPowerupController>().Element == wallElement){
                playerObj.GetComponent<PlayerPowerupController>().UsedElement();
                Destroy(this);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            if(playerObj.GetComponent<PlayerPowerupController>().Element != wallElement && playerObj.GetComponent<PlayerController>().InGround){
                playerObj.GetComponent<PlayerController>().ElementalContact = true;
                scenario.DoubleRotation();
            }
        }
    }
}
