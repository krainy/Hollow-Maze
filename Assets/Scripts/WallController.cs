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

    [SerializeField] PlayerPowerupController playerPowerup;
    [SerializeField] ScenarioController scenario;

    // Start is called before the first frame update
    void Start()
    {
        playerPowerup = GameObject.Find("weeee").GetComponent<PlayerPowerupController>();
        scenario = GameObject.Find("Walls").GetComponent<ScenarioController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            if(playerPowerup.Element == wallElement){
                playerPowerup.UsedElement();
                Destroy(this);
            } else {
                scenario.DoubleRotation();
            }
        }
    }
}
