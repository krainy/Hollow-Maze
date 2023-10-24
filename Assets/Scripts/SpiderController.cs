using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{

    [SerializeField] GameObject playerObj;
    [SerializeField] int spiderElement;
    [SerializeField] Animator spiderAnim;
    //[SerializeField] PlayerLifeController playerLife;
    //[SerializeField] PlayerPowerupController playerPowerUp;

    // Start is called before the first frame update

    IEnumerator SpiderCanDisappear()
    {
        Camera mainCamera = GameObject.Find("Auxiliar Camera").GetComponent<Camera>();
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.gameObject.GetComponent<Transform>().position);
        if (!(viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1))
        {
            Destroy(this.gameObject);
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(SpiderCanDisappear());
        }
    }

    void Start()
    {
        playerObj = GameObject.Find("Rogerio");
        spiderAnim = this.gameObject.GetComponent<Animator>();
        spiderAnim.SetInteger("Element", spiderElement);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerObj.GetComponent<DEMOPlayerPowerup>().Element = spiderElement;

            if (spiderElement == 0)
            {
                playerObj.GetComponent<MinimapController>().CanSeeElementalWalls = true;
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

                if (spiderElement == 0)
                {
                    playerObj.GetComponent<MinimapController>().CanSeeSpiders = true;
                    StartCoroutine(SpiderCanDisappear());
                }

            }

        }
    }

}
