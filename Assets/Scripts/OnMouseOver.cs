using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{

    [SerializeField] bool mouseOnHover = false;


    [SerializeField] state whichUsage;
    enum state
    {
        fullMenuController,
    }

    [SerializeField] NewGameMenuController hoverController;
    [SerializeField] GameObject GameController;
    [SerializeField] GameObject fullMenu;
    [SerializeField] int setAnim;

    void Awake()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }
    }

    void OnMouseEnter()
    {
        switch (whichUsage)
        {
            case state.fullMenuController:
                hoverController.ChangeButton(this.gameObject);
                fullMenu.GetComponent<FullMenuController>().SetMouseHoverIndex = setAnim;
                break;
        }

    }

    void OnMouseExit()
    {
        mouseOnHover = !mouseOnHover;
    }

    void OnMouseDown()
    {
        switch (whichUsage)
        {
            case state.fullMenuController:
                if (this.gameObject.name != "Exit")
                {
                    GameController.GetComponent<ScenesManager>().sceneLoadAdditive(this.gameObject.name);
                }
                else
                {
                    Application.Quit();
                }
                break;
        }


    }

    public void LoadFullMenu(int index)
    {
        fullMenu.GetComponent<FullMenuController>().SetAnimIndex = index;
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
