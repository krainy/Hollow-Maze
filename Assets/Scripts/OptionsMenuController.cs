using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] GameObject[] optionsScreens;
    [SerializeField] Button[] screensButtons;
    [SerializeField] int ScreenIndex = 0;

    GameObject GameController;

    void Start()
    {
        if (GameController == null)
        {

            GameController = GameObject.Find("GameController");
        }

        optionsScreens[0].GetComponent<Camera>().depth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[1]))
        {
            ScreenIndex--;
            if (ScreenIndex < 0)
            {
                ScreenIndex = optionsScreens.Length - 1;
            }
            screensButtons[ScreenIndex].onClick.Invoke();
        }
        else if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[0]))
        {
            ScreenIndex++;
            if (ScreenIndex > optionsScreens.Length - 1)
            {
                ScreenIndex = 0;
            }
            screensButtons[ScreenIndex].onClick.Invoke();
        }

        if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[3]))
        {
            ScenesManager.sceneUnloadThisScene();
        }
    }

    public void ChangeScreen(int screenIndex)
    {

        ScreenIndex = screenIndex;

        foreach (GameObject screen in optionsScreens)
        {
            screen.GetComponent<Camera>().depth = -1;
        }

        optionsScreens[screenIndex].GetComponent<Camera>().depth = 1;

        // foreach (GameObject screen in optionsScreens)
        // {
        //     if (screen == null && index == 0)
        //     {
        //         optionsScreens[0] = optionsScreens[1];
        //         optionsScreens[1] = null;

        //         optionsScreens[0].GetComponent<Camera>().depth = 1;
        //     } else if(screen == null){
        //         optionsScreens[index] = optionsScreens[0];
        //         optionsScreens[0] = null;
        //         optionsScreens[index].GetComponent<Camera>().depth = -1;
        //     }

        //     index++;
        // }
    }

    public void ShutDownCanvas(GameObject canvas)
    {
        canvas.SetActive(false);
    }

    public void AwakenCanvas(GameObject canvas)
    {
        canvas.SetActive(true);
    }
}
