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

    IEnumerator StartGame()
    {


        foreach (TMP_Text txt in textGameObjects)
        {
            yield return new WaitForSeconds(timeBetweenFadeIn);

        }

        yield return new WaitForSeconds(timeToStartGame);
        gameController.GetComponent<ScenesManager>().sceneLoadAsync("Game");

        yield return null;
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
        if (Input.anyKey)
        {

            gameController.GetComponent<ScenesManager>().sceneLoadAsync("Game");
        }
    }
}
