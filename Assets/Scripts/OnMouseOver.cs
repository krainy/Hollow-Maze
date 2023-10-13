using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOver : MonoBehaviour
{

    [SerializeField] bool mouseOnHover = false;

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
        hoverController.ChangeButton(this.gameObject);
        fullMenu.GetComponent<FullMenuController>().SetAnimIndex = setAnim;
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
