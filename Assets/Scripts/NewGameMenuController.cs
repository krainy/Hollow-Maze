using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewGameMenuController : MonoBehaviour
{
    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;

    [SerializeField] GameObject[] buttons;

    void Awake()
    {
        //button1.GetComponent<Animator>().SetBool("OnNewGameButton", true);

        if(buttons == null){
            buttons = GameObject.FindGameObjectsWithTag("Button");
        }

        buttons[0].GetComponent<Animator>().SetBool("onHover", true);
    }

    void Update()
    {

    }

    public void ChangeButton(GameObject buttonGameObject)
    {
        foreach(GameObject obj in buttons){
            if(obj == buttonGameObject){
                obj.GetComponent<Animator>().SetBool("onHover", true);
            } else {
                obj.GetComponent<Animator>().SetBool("onHover", false);
            }
        }
    }
}
