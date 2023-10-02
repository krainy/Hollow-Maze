using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    [SerializeField] GameObject playerObj;
    //[SerializeField] PlayerLifeController playerLife;
    //[SerializeField] PlayerPowerupController playerPowerUp;

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
        if (collider.gameObject.CompareTag("Player"))
        {

            if (playerObj.GetComponent<DEMOPlayerPowerup>().Element == 0)
            {
                playerObj.GetComponent<DEMOPlayerPowerup>().Element = 1;
            }

            if (playerObj.GetComponent<Rigidbody2D>().velocity.y <= -20)
            {
                Debug.Log("Matou a aranha rapá");

                playerObj.GetComponent<DEMOPlayerPowerup>().Killer = 1;

                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Né que chegou sem matar a aranha, congratulaixons!");

            }

        }
    }

}
