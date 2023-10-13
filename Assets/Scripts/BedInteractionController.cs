using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BedInteractionController : MonoBehaviour
{

    [SerializeField] TMP_Text DialogueText;
    [SerializeField] int dialogueIterator = 0;
    [SerializeField] string[] dialogues;
    [SerializeField] float[] dialoguesTimes;
    bool canShowDialogue = true;


    IEnumerator DialogueDisplay()
    {
        yield return new WaitForSeconds(2f);
        foreach (string str in dialogues)
        {
            DialogueText.text = str.Replace("\\n", "\n");
            yield return new WaitForSeconds(dialoguesTimes[dialogueIterator]);
            dialogueIterator++;
        }
        StopAllCoroutines();
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && canShowDialogue)
        {
            canShowDialogue = false;
            StartCoroutine(DialogueDisplay());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            canShowDialogue = true;
            DialogueText.text = "";
            StopAllCoroutines();
            dialogueIterator = 0;
        }
    }
}
