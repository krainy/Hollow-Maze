using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{

    [SerializeField] bool mouseOnHover = false;

    [SerializeField] NewGameMenuController hoverController;
    [SerializeField] GameObject GameController;

    void Awake()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }
    }

    void OnMouseEnter()
    {
        hoverController.ChangeButton(this.gameObject);
    }

    void OnMouseExit()
    {
        mouseOnHover = !mouseOnHover;
    }

    void OnMouseDown()
    {

        if (this.gameObject.name != "Exit")
        {
            GameController.GetComponent<ScenesManager>().sceneLoadAdditive(this.gameObject.name);
        }
        else
        {
            Application.Quit();
        }


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


}
