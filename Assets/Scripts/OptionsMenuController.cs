using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField] GameObject[] optionsScreens;

    void Start()
    {

        optionsScreens[0].GetComponent<Camera>().depth = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScreen(int screenIndex)
    {

        Debug.Log("g");

        foreach(GameObject screen in optionsScreens){
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
}
