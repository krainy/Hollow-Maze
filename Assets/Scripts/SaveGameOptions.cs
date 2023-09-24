using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameOptions : MonoBehaviour
{

    /// <summary>
    /// ACCESSIBILITY OPTIONS
    /// </summary>
    [SerializeField] float cameraDistance;
    public float CameraDistance
    {
        set { cameraDistance = value; }
    }
}
