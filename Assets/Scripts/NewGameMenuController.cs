using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameMenuController : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    [SerializeField] GameObject[] buttons;

    [SerializeField] int buttonIndex = 0;

    [SerializeField] GameObject GameController;

    void Start()
    {
        //button1.GetComponent<Animator>().SetBool("OnNewGameButton", true);

        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }

        if (buttons == null)
        {
            buttons = GameObject.FindGameObjectsWithTag("Button");
        }

        ChangeButtonByInt();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && buttonIndex < buttons.Length - 1)
        {
            buttonIndex++;
            ChangeButtonByInt();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && buttonIndex > 0)
        {
            buttonIndex--;
            ChangeButtonByInt();
        }

        if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[4]))
        {
            EnterScene();
        }
    }

    public void ChangeButton(GameObject buttonGameObject)
    {
        int index = 0;
        foreach (GameObject obj in buttons)
        {
            if (obj == buttonGameObject)
            {
                obj.GetComponent<Animator>().SetBool("onHover", true);
                buttonIndex = index;
            }
            else
            {
                obj.GetComponent<Animator>().SetBool("onHover", false);
            }
            index++;
        }
    }

    public void ChangeButtonByInt()
    {
        int index = 0;
        foreach (GameObject obj in buttons)
        {
            if (index == buttonIndex)
            {
                obj.GetComponent<Animator>().SetBool("onHover", true);
            }
            else
            {
                obj.GetComponent<Animator>().SetBool("onHover", false);
            }
            index++;
        }
    }

    void EnterScene()
    {
        int index = 0;
        foreach (GameObject obj in buttons)
        {
            if (index == buttonIndex)
            {
                if (obj.gameObject.name != "Exit")
                {
                    GameController.GetComponent<ScenesManager>().sceneLoadAdditive(obj.gameObject.name);
                }
                else
                {
                    Application.Quit();
                }
            }

            index++;
        }
    }
}
