using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSquareController : MonoBehaviour
{
    [SerializeField] GameObject MapFog;
    [SerializeField] Camera mainCamera;
    bool isComputing = false;

    void OnEnable()
    {
        if (this.gameObject.scene.name == "DontDestroyOnLoad" && mainCamera != null && MapFog != null)
        {
            print("comecou");
            StartCoroutine(FOGController());
        }
    }


    IEnumerator FOGController()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(MapFog.GetComponent<Transform>().position);
        if (viewPos.x >= 0 && viewPos.y >= 0 && viewPos.x <= 1 && viewPos.y <= 1)
        {
            Destroy(MapFog);
            this.enabled = false;
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FOGController());
        }



    }

    void Start()
    {
        if (this.gameObject.CompareTag("ElementalWall"))
        {
            if (!GameObject.Find("Rogerio").GetComponent<MinimapController>().CanSeeElementalWalls)
            {
                MapFog.SetActive(true);
            }
        }
        else
        {

            MapFog.SetActive(true);

        }

        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
        StartCoroutine(FOGController());
    }



    void OnTriggerEnter2D(Collider2D collider)
    {
        if (GameObject.Find("Rogerio").GetComponent<MinimapController>().CanSeeElementalWalls)
        {
            if (collider.gameObject.CompareTag("ElementalWall"))
            {
                Destroy(MapFog);
            }
        }

        if (GameObject.Find("Rogerio").GetComponent<MinimapController>().CanSeeSpiders)
        {
            if (collider.gameObject.CompareTag("Spider"))
            {
                Destroy(MapFog);
            }
        }
    }
}
