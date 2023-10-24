using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrologueController : MonoBehaviour
{
    [SerializeField] GameObject gameController;
    [SerializeField] List<TMP_Text> textGameObjects = new List<TMP_Text>();
    [SerializeField][Tooltip("In Seconds")] int timeToFadeIn = 1;
    [SerializeField][Tooltip("In Seconds")] int timeBetweenFadeIn = 2;
    [SerializeField][Tooltip("In Seconds")] int timeToStartGame = 10;
    bool anyKeyDown = false;

    [SerializeField] TMP_Text pressButtonText;
    bool endingPrologue = false;

    IEnumerator AlphaChange_PressButtonText()
    {
        yield return new WaitForSeconds(1f);


        for (float i = 0; i <= 1; i += 2f * Time.deltaTime)
        {
            // set color with i as alpha
            pressButtonText.color = new Color(1, 1, 1, i);
            yield return null;
        }

        while (!endingPrologue)
        {
            yield return new WaitForEndOfFrame();
        }

        for (float i = 1; i > 0; i -= 2f * Time.deltaTime)
        {
            // set color with i as alpha
            pressButtonText.color = new Color(1, 1, 1, i);
            yield return null;
        }

    }

    IEnumerator StartGame()
    {


        foreach (TMP_Text txt in textGameObjects)
        {
            yield return new WaitForSeconds(timeBetweenFadeIn);

        }

        endingPrologue = true;



        yield return new WaitForSeconds(timeToStartGame - 2);

        foreach (TMP_Text txt in textGameObjects)
        {
            StartCoroutine("textFadeOut", txt);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(4f);

        gameController.GetComponent<ScenesManager>().sceneLoadAsync("GameContent");

        yield return null;
    }

    IEnumerator textFadeOut(TMP_Text text)
    {
        for (float i = 2f; i >= 0; i -= Time.deltaTime)
        {
            float alpha = i / 2;

            // set color with i as alpha
            text.color = new Color(1, 1, 1, alpha);
            yield return null;
        }
    }

    IEnumerator textFadeIn(TMP_Text text)
    {
        for (float i = 0; i <= timeToFadeIn; i += Time.deltaTime)
        {
            // set color with i as alpha
            text.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    IEnumerator Initialize()
    {
        StartCoroutine(StartGame());
        foreach (TMP_Text txt in textGameObjects)
        {
            StartCoroutine("textFadeIn", txt);
            yield return new WaitForSeconds(timeBetweenFadeIn);
        }
    }

    void Start()
    {
        StartCoroutine(AlphaChange_PressButtonText());

        gameController = GameObject.Find("GameController");

        foreach (TMP_Text txt in textGameObjects)
        {
            txt.color = new Color(1, 1, 1, 0);
        }

        StartCoroutine(Initialize());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !anyKeyDown)
        {
            Debug.Log("Pulou a introducao msm vei");

            anyKeyDown = true;

            gameController.GetComponent<ScenesManager>().sceneLoadAsync("GameContent");
        }
    }
}
