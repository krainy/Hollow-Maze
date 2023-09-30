using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{

    [SerializeField] private GameObject mazeWalls;
    [SerializeField] private GameObject playerGO;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] private PlayerController playerScript;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private bool rotating = false;
    public bool Rotating
    {
        get { return rotating; }
    }

    IEnumerator RotateWalls(int rotation)
    {
        rotating = true;

        //playerScript.CanJump = true;
        float iniRotate = this.transform.localRotation.eulerAngles.z;
        int rotateSide = Mathf.Abs(rotation) / rotation;
        int rotateMagnitude = Mathf.Abs(rotation / 90);

        if (rotation != 180)
        {
            //playerScript.CanJump = true;
            Quaternion target = Quaternion.Euler(this.transform.localRotation.eulerAngles.x, this.transform.localRotation.eulerAngles.y, this.transform.localRotation.eulerAngles.z + rotation);

            if (iniRotate + rotation < 0)
            {
                iniRotate += 360;
            }
            else if (iniRotate + rotation >= 360)
            {
                iniRotate -= 360;
            }

            Debug.Log("Rotação inicial: " + iniRotate);
            Debug.Log("Rotação final: " + (iniRotate + rotation));

        }

        while (!playerScript.AbleToRotate)
        {
            Debug.Log("Esperando poder rotacionar o mundo!!!");
            yield return new WaitForEndOfFrame();
        }

        for (float i = 0; i < 90; i += rotateSpeed * Time.deltaTime)
        {

            transform.RotateAround(playerGO.transform.position, new Vector3(0f, 0f, (1f * rotateSide)), Time.deltaTime * rotateSpeed * rotateMagnitude);
            yield return new WaitForEndOfFrame();

        }

        Debug.Log("Terminando de girar");

        //int gambiarra = Mathf.RoundToInt(Mathf.Abs(this.transform.localRotation.eulerAngles.z) / this.transform.localRotation.eulerAngles.z);

        //transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.RoundToInt(this.transform.localRotation.eulerAngles.z / 90) * 90);

        //Teste com rotate around

        int aux = Mathf.RoundToInt(this.transform.localRotation.eulerAngles.z / 90);
        Debug.Log("aux = " + aux);
        float quantofalta = (90 * aux) - this.transform.localRotation.eulerAngles.z;
        Debug.Log("Quanto falta = " + quantofalta);

        transform.RotateAround(playerGO.transform.position, new Vector3(0f, 0f, 1f), quantofalta);

        Debug.Log("Terminou de girar :)");
        playerScript.CanFall = true;
        playerScript.AbleToRotate = false;
        rotating = false;
        StopAllCoroutines();
        yield return null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && playerScript.InGround)
        {
            Rotation("clockwise");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && playerScript.InGround)
        {
            Rotation("anticlockwise");
        }
    }

    void Rotation(string side)
    {
        if (side == "clockwise" && !rotating)
        {
            rotating = true;
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(-90));

        }
        else if (side == "anticlockwise" && !rotating)
        {
            rotating = true;
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(90));

        }
    }

    public void DoubleRotation()
    {
        if (!rotating)
        {
            rotating = true;

            StartCoroutine(RotateWalls(180));

        }
    }
}
