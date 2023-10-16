using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField] GameObject GameController;
    [SerializeField] GameObject menuArrow;
    [SerializeField] GameObject[] buttons;
    [SerializeField] int buttonIndex;
    bool gerson = true;

    // Start is called before the first frame update
    void Start()
    {
        GameController = GameObject.Find("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.sceneCount <= 2)
        {
            if ((Input.GetAxis("Joystick Selection") == -1 || Input.GetKeyDown(KeyCode.DownArrow)) && gerson && buttonIndex < buttons.Length - 1)
            {
                gerson = false;
                buttonIndex++;
                AttArrowY();
            }
            else if ((Input.GetAxis("Joystick Selection") == 1 || Input.GetKeyDown(KeyCode.UpArrow)) && gerson && buttonIndex > 0)
            {
                gerson = false;
                buttonIndex--;
                AttArrowY();
            }
            if (Input.GetAxis("Joystick Selection") == 0)
            {
                gerson = true;
            }

            if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[4]))
            {
                EnterScene();
            }
        }
    }

    void AttArrowY(){
        menuArrow.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, buttons[buttonIndex].GetComponent<RectTransform>().anchoredPosition.y, 0f);
    }

    void EnterScene()
    {
        int index = 0;
        foreach (GameObject obj in buttons)
        {
            if (index == buttonIndex)
            {
                obj.GetComponent<Button>().onClick.Invoke();
            }

            index++;
        }
    }
}
