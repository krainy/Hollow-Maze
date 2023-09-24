using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AccessibilityController : MonoBehaviour
{

    [SerializeField] GameObject gameImage;
    [SerializeField] GameObject gameControllerScript;
    [SerializeField] Slider zoomSlider;

    [SerializeField] Transform cameraTransform;

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

        float cameraZoom = -15f + (zoomSlider.value * 10f);

        gameControllerScript.GetComponent<SaveGameOptions>().CameraDistance = cameraZoom;

        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, cameraZoom);
    }
}
