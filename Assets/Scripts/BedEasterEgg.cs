using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedEasterEgg : MonoBehaviour
{
    [SerializeField] int timeToEasterEgg;
    [SerializeField] ButtonForScenes objectForSceneChange;

    IEnumerator EasterEgg()
    {
        while (!this.gameObject.GetComponent<BedInteractionController>().DialogueEnd)
        {

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(timeToEasterEgg);

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().HasGoodEnding)
        {
            objectForSceneChange.CallScene("GoodLevelWin");
        }
        else
        {
            objectForSceneChange.CallScene("BadLevelWin");
        }


    }

    void Start()
    {
        objectForSceneChange = GameObject.Find("GameCanvas").GetComponent<ButtonForScenes>();

        StartCoroutine(EasterEgg());
    }

    public void StopCoroutines()
    {
        StopAllCoroutines();
    }
}
