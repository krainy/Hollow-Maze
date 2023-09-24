using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try{
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, cameraTransform.position.z);
        } catch {
            Debug.Log("Nenhum target adicionado!");
        }
    }
}
