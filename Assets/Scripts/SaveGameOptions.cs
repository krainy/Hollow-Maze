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
    [SerializeField] bool useJoystickAxis = false;
    public bool UseJoystickAxis
    {
        get { return useJoystickAxis; }
        set { useJoystickAxis = value; }
    }

    public float CameraDistance
    {
        set { cameraDistance = value; }
        get { return cameraDistance; }
    }
}
