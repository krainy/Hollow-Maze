using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour
{

    [SerializeField] GameObject GameController;
    [SerializeField] private GameObject mazeWalls;
    [SerializeField] private GameObject playerGO;
    [SerializeField] RectTransform rectTransform;
    [SerializeField] private PlayerController playerScript;
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] bool usingKeyboard = false;
    [SerializeField] bool canRotate = false;
    public bool CanRotate
    {
        get { return canRotate; }
        set { canRotate = value; }
    }

    [SerializeField] private bool rotating = false;
    public bool Rotating
    {
        get { return rotating; }
    }

    void Start()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }
    }

    IEnumerator RotateWalls(int rotation)
    {
        rotating = true;
        canRotate = false;

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
        CheckInput();

    }

    void CheckInput()
    {
        if (Time.timeScale != 0 && playerScript.InGround && canRotate)
        {
            KeyboardInputs();

            JoystickInputs();

        }
    }

    void KeyboardInputs()
    {
        if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[0]))
        {
            GameController.GetComponent<KeyConfigController>().UsingJoystick = false;
            Rotation("clockwise");
        }
        else if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[1]))
        {
            GameController.GetComponent<KeyConfigController>().UsingJoystick = false;
            Rotation("anticlockwise");
        }
    }

    void JoystickInputs()
    {
        if (GameController.GetComponent<SaveGameOptions>().UseJoystickAxis)
        {
            if (Mathf.Abs(Input.GetAxisRaw("JoyHorizontal")) / Input.GetAxisRaw("JoyHorizontal") < 0)
            {
                GameController.GetComponent<KeyConfigController>().UsingJoystick = true;
                Debug.Log("b");
                Rotation("clockwise");
            }
            else if ((Mathf.Abs(Input.GetAxisRaw("JoyHorizontal")) / Input.GetAxisRaw("JoyHorizontal")) > 0)
            {
                GameController.GetComponent<KeyConfigController>().UsingJoystick = true;
                Rotation("anticlockwise");
            }
        }
    }

    void Rotation(string side)
    {
        if (side == "clockwise" && !rotating)
        {
            rotating = true;
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(90));

        }
        else if (side == "anticlockwise" && !rotating)
        {
            rotating = true;
            playerScript.CanJump = true;
            StartCoroutine(RotateWalls(-90));

        }
    }

    public void DoubleRotation()
    {
        if (!rotating)
        {
            rotating = true;
            playerScript.CanJump = true;

            StartCoroutine(RotateWalls(180));

        }
    }

    IEnumerator FreeRotation()
    {
        yield return new WaitForSeconds(.1f);
        canRotate = true;
        yield return null;
    }

    public void ToFreeRotation()
    {
        StartCoroutine(FreeRotation());
    }
}
