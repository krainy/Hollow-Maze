using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameOptions : MonoBehaviour
{

    /// <summary>
    /// ACCESSIBILITY OPTIONS
    /// </summary>
    [SerializeField] float cameraDistance;
    [SerializeField] bool lerpCamera = false;
    public bool LerpCamera
    {
        get { return lerpCamera; }
        set { lerpCamera = value; }
    }
    public float CameraDistance
    {
        set { cameraDistance = value; }
        get { return cameraDistance; }
    }
}
