using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDissonanceController : MonoBehaviour
{
    [SerializeField] bool spiderLevelDissonance = false;
    int spiderLevelDissonanceIndex = 0;
    [SerializeField] GameObject GameController;
    [SerializeField] LocalSpawnsController setPlayerPosition;
    [SerializeField] GameObject waterLevelSpawn;
    [SerializeField] WaterLevelController levelDissonance;
    [SerializeField] int localDissonance = 0;


    void Start()
    {
        GameController = GameObject.Find("GameController");
        levelDissonance = this.gameObject.GetComponentInParent<WaterLevelController>();
        setPlayerPosition = this.gameObject.GetComponentInParent<LocalSpawnsController>();
    }


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (levelDissonance.WaterDissonance != localDissonance)
            {
                if (!spiderLevelDissonance)
                {
                    levelDissonance.WaterDissonance = localDissonance;

                    setPlayerPosition.UseSpawn(waterLevelSpawn);
                } else {
                    spiderLevelDissonanceIndex++;
                    if(spiderLevelDissonanceIndex == 6){
                        //load spider level
                        Debug.Log("Spider Level on Load");
                    }
                }


            }
        }
    }
}
