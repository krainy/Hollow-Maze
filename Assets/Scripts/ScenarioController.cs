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
        playerScript.CanJump = true;
        float iniRotate = this.transform.localRotation.eulerAngles.z;
        int rotateSide = rotation / 90;
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

        while(!playerScript.AbleToRotate){
            yield return new WaitForEndOfFrame();
        }

        while ((int)this.transform.localRotation.eulerAngles.z != iniRotate + rotation)
        {
            Debug.Log("Ta girando");
            //Debug.Log((int)this.transform.localRotation.eulerAngles.z);
            //transform.rotateAround = Quaternion.Lerp(transform.rotation, target, Time.deltaTime * rotateSpeed);
            transform.RotateAround(playerGO.transform.position, new Vector3(0f, 0f, (1f * rotateSide)), Time.deltaTime * rotateSpeed);
            if (Mathf.Abs((iniRotate + rotation) - this.transform.localRotation.eulerAngles.z) < 1)
            {
                Debug.Log("Terminou de girar :)");
                playerScript.CanFall = true;
                playerScript.AbleToRotate = false;
                rotating = false;
                StopAllCoroutines();
                yield return null;
            }
            yield return new WaitForEndOfFrame();
        }

        Debug.Log("Terminou de girar :)");
        rotating = false;
        yield return null;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rotation("clockwise");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rotation("anticlockwise");
        }
    }

    void Rotation(string side)
    {
        if (side == "clockwise" && !rotating)
        {
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(-90));

        }
        else if (side == "anticlockwise" && !rotating)
        {
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(90));

        }
    }
}
