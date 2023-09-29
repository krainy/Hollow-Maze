using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccessibilityController : MonoBehaviour
{

    [SerializeField] GameObject gameImage;
    [SerializeField] GameObject gameControllerScript;
    [SerializeField] Slider zoomSlider;

    [SerializeField] Camera cameraObject;

    float cameraZoom;
    

    IEnumerator DroppinCoroutine(){
        gameImage.SetActive(false);

        return null;
    }

    void Start()
    {

        gameControllerScript = GameObject.Find("GameController");

        // zoomSlider = GetComponent<Slider>();

        // cameraTransform = GetComponent<Transform>();
    }

    public void Draggin(){
        gameImage.SetActive(true);
    }

    public void Droppin(){
        StartCoroutine("DroppinCoroutine", 1f);
    }

    public void zoomChange(){
        Debug.Log("Mudando o zoom da camera!");

        cameraZoom = 13.5f - (zoomSlider.value * 9f);

        gameControllerScript.GetComponent<SaveGameOptions>().CameraDistance = cameraZoom;

        cameraObject.orthographicSize = cameraZoom;
    }

    public void boolChange(){
        gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera = !gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera;
    }
}
