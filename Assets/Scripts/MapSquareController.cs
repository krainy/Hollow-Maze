using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSquareController : MonoBehaviour
{
    [SerializeField] GameObject MapFog;

    void Awake()
    {
        MapFog.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(MapFog);
        }
    }
}
