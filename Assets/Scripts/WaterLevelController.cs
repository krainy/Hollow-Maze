using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelController : MonoBehaviour
{
    [SerializeField] int waterDissonance = 0;
    [SerializeField] bool hasSeenWaterDissonance = false;
    public bool HasSeenWaterDissonance
    {
        get { return hasSeenWaterDissonance; }
        set { hasSeenWaterDissonance = value; }
    }

    
    public int WaterDissonance
    {
        get { return waterDissonance; }
        set { waterDissonance = value; }
    }
}
