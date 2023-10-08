using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBoardSettingsController : MonoBehaviour
{

    [SerializeField][Tooltip(" 0 = Girar horario;\n 1 = Girar antihorario;\n 2 = Mapa;\n 3 = Pause;\n 4 = Selecionar")] TMP_Text[] keysText;

    [SerializeField] GameObject GameController;

    bool usingJoystick = false;

    // Start is called before the first frame update
    void Start()
    {

        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }

        StartCoroutine(CheckAtualInput());

        int keysIndex = 0;
        foreach (KeyCode key in GameController.GetComponent<KeyConfigController>().KeysList)
        {
            keysText[keysIndex].text = key.ToString();
            keysIndex++;
        }
    }

    IEnumerator ChangingKey(TMP_Text buttonText)
    {
        while (!GameController.GetComponent<KeyConfigController>().UsingKeyPressed)
        {
            yield return new WaitForEndOfFrame();
        }

        GameController.GetComponent<KeyConfigController>().UsingKeyPressed = false;

        int keysIndex = 0;
        foreach (KeyCode key in GameController.GetComponent<KeyConfigController>().KeysList)
        {
            keysText[keysIndex].text = key.ToString();
            keysIndex++;
        }
    }

    public void ChangeKey(TMP_Text buttonText)
    {
        buttonText.text = "Press any key";

        StartCoroutine("ChangingKey", buttonText);
    }

    public void ChangeValue(int keyIndex)
    {
        GameController.GetComponent<KeyConfigController>().ChangeValue(keyIndex);
    }

    IEnumerator CheckAtualInput()
    {
        if (GameController.GetComponent<KeyConfigController>().UsingJoystick != usingJoystick)
        {
            usingJoystick = !usingJoystick;
            int keysIndex = 0;
            foreach (KeyCode key in GameController.GetComponent<KeyConfigController>().KeysList)
            {
                keysText[keysIndex].text = key.ToString();
                keysIndex++;
            }
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(CheckAtualInput());

    }


}
