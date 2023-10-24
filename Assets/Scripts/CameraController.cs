using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Camera cameraOBJ;
    [SerializeField] GameObject GameController;
    [SerializeField] Transform mazeWalls;


    void Start()
    {
        GameObject[] camera = GameObject.FindGameObjectsWithTag(this.gameObject.name);

        if (camera.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        target = GameObject.Find("Rogerio").GetComponent<Transform>();
        mazeWalls = GameObject.FindGameObjectWithTag(this.gameObject.tag).GetComponent<Transform>();
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
            else
            {
                this.cameraTransform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (GameController.GetComponent<SaveGameOptions>().CameraDistance > 1)
            {
                cameraOBJ.orthographicSize = GameController.GetComponent<SaveGameOptions>().CameraDistance;
            }
            else
            {
                cameraOBJ.orthographicSize = 1f;
            }


        }
        else
        {
            GameController = GameObject.Find("GameController");
        }

    }
}
