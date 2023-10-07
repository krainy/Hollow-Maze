using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccessibilityController : MonoBehaviour
{

    [SerializeField] GameObject gameImage;
    [SerializeField] GameObject gameControllerScript;
    [SerializeField] Slider zoomSlider;
    [SerializeField] Toggle cameraToggle;

    [SerializeField] Camera cameraObject;
    [SerializeField] GameObject accessibilityCamera;
    [SerializeField] GameObject gameCamera;

    float cameraZoom;


    IEnumerator DroppinCoroutine()
    {
        //gameImage.SetActive(false);

        return null;
    }

    

    void Start()
    {
        gameControllerScript = GameObject.Find("GameController");

        if(gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera){
            cameraToggle.SetIsOnWithoutNotify(true);
        }

        if (gameCamera == null)
        {

            gameCamera = GameObject.Find("Game Camera");

        }

        cameraObject.orthographicSize = gameControllerScript.GetComponent<SaveGameOptions>().CameraDistance;
        zoomSlider.value = (13.5f - cameraObject.orthographicSize) / 9f;


        // zoomSlider = GetComponent<Slider>();

        // cameraTransform = GetComponent<Transform>();
    }

    void Update(){
        if(gameCamera != null){
            Debug.Log("Mudando tamanho da camera");
            accessibilityCamera.GetComponent<Transform>().position = gameCamera.GetComponent<Transform>().position;
            accessibilityCamera.GetComponent<Transform>().rotation = gameCamera.GetComponent<Transform>().rotation;
        }
    }

    public void Draggin()
    {
        //gameImage.SetActive(true);
    }

    public void Droppin()
    {
        StartCoroutine("DroppinCoroutine", 1f);
    }

    public void zoomChange()
    {
        Debug.Log("Mudando o zoom da camera!");

        cameraZoom = 13.5f - (zoomSlider.value * 9f);

        gameControllerScript.GetComponent<SaveGameOptions>().CameraDistance = cameraZoom;

        cameraObject.orthographicSize = cameraZoom;
    }

    public void boolChange()
    {
        gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera = !gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera;
        if(!gameControllerScript.GetComponent<SaveGameOptions>().LerpCamera){
            accessibilityCamera.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
