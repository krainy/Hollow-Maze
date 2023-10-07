using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyBoardSettingsController : MonoBehaviour
{

    [SerializeField][Tooltip(" 0 = Girar horario;\n 1 = Girar antihorario;\n 2 = Mapa;\n 3 = Pause;\n 4 = Selecionar")] TMP_Text[] keysText;

    [SerializeField] GameObject GameController;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController == null)
        {
            GameController = GameObject.Find("GameController");
        }

        int keysIndex = 0;
        foreach (KeyCode key in GameController.GetComponent<KeyConfigController>().KeysList)
        {
            keysText[keysIndex].text = key.ToString();
            keysIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {

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


}
