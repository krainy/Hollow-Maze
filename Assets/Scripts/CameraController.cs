using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform cameraTransform;
    [SerializeField]
    Camera camera;


    [SerializeField] GameObject GameController;
    [SerializeField] Transform mazeWalls;


    void Start()
    {

    }

    void Update()
    {
        try
        {
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, cameraTransform.position.z);
        }
        catch
        {
            Debug.Log("Nenhum target adicionado!");
        }

        //para girar apenas o personagem:
        if (GameController != null)
        {
            if (GameController.GetComponent<SaveGameOptions>().LerpCamera)
            {
                Quaternion mazeRotation = Quaternion.Euler(cameraTransform.rotation.x, cameraTransform.rotation.y, mazeWalls.rotation.z);

                this.cameraTransform.rotation = Quaternion.Lerp(transform.rotation, mazeWalls.rotation, 1);
            }
            if (GameController.GetComponent<SaveGameOptions>().CameraDistance > 1)
            {
                camera.orthographicSize = GameController.GetComponent<SaveGameOptions>().CameraDistance;
            } else {
                camera.orthographicSize = 1f;
            }


        }
        else
        {
            GameController = GameObject.Find("GameController");
        }

    }
}
