using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BedInteractionController : MonoBehaviour
{

    [SerializeField] TMP_Text DialogueText;
    [SerializeField] int dialogueIterator = 0;

    [SerializeField] bool interactOnlyOnce;
    bool interacted = false;
    [SerializeField] int indexOfEndDialogue;
    [SerializeField] bool dialogueEnd = false;
    public bool DialogueEnd
    {
        get { return dialogueEnd; }
    }
    [SerializeField] string[] dialogues;
    [SerializeField] float[] dialoguesTimes;
    bool canShowDialogue = true;

    void Start(){
        DialogueText = GameObject.Find("Dialogue Text").GetComponent<TMP_Text>();
    }

    IEnumerator DialogueDisplay()
    {
        yield return new WaitForSeconds(2f);
        foreach (string str in dialogues)
        {
            DialogueText.text = str.Replace("\\n", "\n");

            if (interactOnlyOnce)
            {
                if (dialogueIterator == indexOfEndDialogue)
                {
                    interacted = true;
                }
            }

            yield return new WaitForSeconds(dialoguesTimes[dialogueIterator]);
            dialogueIterator++;
        }

        dialogueEnd = true;

        StopAllCoroutines();
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && canShowDialogue && !interacted)
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
            this.gameObject.GetComponent<BedEasterEgg>().StopCoroutines();
            DialogueText.text = "";
            StopAllCoroutines();
            dialogueIterator = 0;
        }
    }
}

