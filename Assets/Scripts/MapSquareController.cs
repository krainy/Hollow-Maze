using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSquareController : MonoBehaviour
{
    [SerializeField] GameObject MapFog;
    [SerializeField] Camera mainCamera;


    IEnumerator FOGController()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(MapFog.GetComponent<Transform>().position);
        if (viewPos.x >= 0 && viewPos.y >= 0 && viewPos.x <= 1 && viewPos.y <= 1)
        {
            Destroy(MapFog);
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(FOGController());
        }



    }

    void Awake()
    {
        MapFog.SetActive(true);
        mainCamera = GameObject.Find("Game Camera").GetComponent<Camera>();

        StartCoroutine(FOGController());
    }



    /*void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(MapFog);
        }
    }*/
}
