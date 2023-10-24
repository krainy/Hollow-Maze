using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{

    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject GameController;
    [SerializeField] bool isMinimapUnlocked = false;
    [SerializeField] bool canSeeElementalWalls;
    public bool CanSeeElementalWalls
    {
        get { return canSeeElementalWalls; }
        set { canSeeElementalWalls = value; }
    }
    [SerializeField] bool canSeeSpiders;
    public bool CanSeeSpiders
    {
        get { return canSeeSpiders; }
        set { canSeeSpiders = value; }
    }

    bool canOpenMinimap = true;


    public bool IsMinimapUnlocked
    {
        set { isMinimapUnlocked = value; }
    }

    void Start()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(GameController.GetComponent<KeyConfigController>().KeysList[2]) && !GameController.GetComponent<PauseController>().GameIsPaused && isMinimapUnlocked && canOpenMinimap)
        {
            miniMap.SetActive(true);
        }
        else if (Input.GetKeyUp(GameController.GetComponent<KeyConfigController>().KeysList[2]) || Input.anyKeyDown)
        {
            miniMap.SetActive(false);
        }
    }

    public void EntersARestrictedArea(){
        miniMap.SetActive(false);
        canOpenMinimap = false;
    }

    public void ExitARestrictedArea(){
        canOpenMinimap = true;
    }

}