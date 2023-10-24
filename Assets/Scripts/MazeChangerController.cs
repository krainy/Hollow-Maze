using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeChangerController : MonoBehaviour
{

    [SerializeField] mazePlayerAre MazePlayerAre;
    enum mazePlayerAre
    {
        initial,
        fire,
        air,
        earth,
        water
    }

    [SerializeField] mazeToGo MazeToGo;
    enum mazeToGo
    {
        initial,
        fire,
        air,
        earth,
        water
    }

    public void ChangeMap()
    {
        switch (MazePlayerAre)
        {
            case mazePlayerAre.initial:

                

                break;
            case mazePlayerAre.fire:



                break;
            case mazePlayerAre.air:



                break;
            case mazePlayerAre.earth:



                break;
            case mazePlayerAre.water:



                break;
        }
    }

}
