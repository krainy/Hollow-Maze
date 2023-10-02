using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEMOPlayerPowerup : MonoBehaviour
{

    [SerializeField] int element = 0;
    public int Element
    {
        get { return element; }
        set { element = value; }
    }
    int killer = 0;
    public int Killer
    {
        get { return killer; }
        set { killer = value; }
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
