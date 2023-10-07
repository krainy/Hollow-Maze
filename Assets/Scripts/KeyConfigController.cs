using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyConfigController : MonoBehaviour
{

    [SerializeField] bool hasJoystick;
    public bool HasJoystick
    {
        get { return hasJoystick; }
    }
    [SerializeField] bool usingJoystick = false;
    public bool UsingJoystick
    {
        get { return usingJoystick; }
        set { usingJoystick = value; }
    }

    bool toChangeKey = false;

    [SerializeField] bool usingKeyboard = true;

    [SerializeField] KeyCode usedKey;
    public KeyCode UsedKey
    {
        get { return usedKey; }
    }
    [SerializeField] bool usingKeyPressed = false;
    public bool UsingKeyPressed
    {
        get { return usingKeyPressed; }
        set { usingKeyPressed = value; }
    }

    [SerializeField]
    [Tooltip(" 0 = Girar horario;\n 1 = Girar antihorario;\n 2 = Mapa;\n 3 = Pause;\n 4 = Selecionar")]
    KeyCode[] keyList;
    [SerializeField]
    [Tooltip(" 0 = Girar horario;\n 1 = Girar antihorario;\n 2 = Mapa;\n 3 = Pause;\n 4 = Selecionar")]
    KeyCode[] joystickKeyList;

    public KeyCode[] KeysList
    {
        get
        {
            if (usingJoystick)
            {
                return joystickKeyList;
            }
            else
            {
                return keyList;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HasActiveJoystick();

        if (hasJoystick)
        {
            WhichInput();
        }
        else
        {
            usingKeyboard = true;
            usingJoystick = false;
        }






        /*if (Input.GetButton("Joystick X"))
        {
            usedKey = "Joystick X";
            Debug.Log("Usando botao X");
        }*/

        /*if(Input.anyKeyDown){
            Debug.Log("Alguma tecla pressionada");
        }*/



    }

    void HasActiveJoystick()
    {
        if (Input.GetJoystickNames()[0] != "")
        {

            hasJoystick = true;

        }
        else
        {

            hasJoystick = false;

        }
    }

    void WhichInput()
    {
        if (hasJoystick && !usingJoystick)
        {
            if (Input.GetAxis("Any Joystick Use") == 1 || Input.GetAxis("Any Joystick Use") == -1)
            {
                usingKeyboard = false;
                usingJoystick = true;
            }
        }

        if (Input.anyKeyDown)
        {
            foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    if (!kcode.ToString().Contains("Mouse"))
                    {
                        usedKey = kcode;
                        Debug.Log(usedKey);
                        if (usedKey.ToString().Contains("Joystick"))
                        {
                            usingKeyboard = false;
                            usingJoystick = true;
                        }
                        else
                        {
                            usingKeyboard = true;
                            usingJoystick = false;
                        }
                        toChangeKey = true;
                    }


                }

            }
        }
    }

    IEnumerator ChangingValue(int keyIndex)
    {
        Debug.Log("b");
        while (!toChangeKey)
        {
            Debug.Log("c");
            yield return new WaitForEndOfFrame();
        }
        toChangeKey = false;
        usingKeyPressed = true;
        Debug.Log("d");
        keyList[keyIndex] = usedKey;

        yield return null;
    }

    public void ChangeValue(int keyIndex)
    {
        Debug.Log("a");
        toChangeKey = false;
        StartCoroutine("ChangingValue", keyIndex);
    }

    /*void OnGUI()
    {
        Event e = Event.current;

        if (Input.anyKeyDown)
        {
            if (e.isKey && e.keyCode.ToString() != "None")
            {
                usingJoystick = false;
                usingKeyboard = true;
            }
        }
    }*/
}
