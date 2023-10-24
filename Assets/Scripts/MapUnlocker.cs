using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUnlocker : MonoBehaviour
{
    BedInteractionController dialogueIterator;
    MinimapController minimap;
    MapUnlockedText textMapIsUnlocked;

    void Awake()
    {
        dialogueIterator = this.gameObject.GetComponent<BedInteractionController>();
        minimap = (MinimapController)FindObjectOfType(typeof(MinimapController));
        textMapIsUnlocked = (MapUnlockedText)FindObjectOfType(typeof(MapUnlockedText));

        StartCoroutine(CheckDialogueStatus());
    }

    IEnumerator CheckDialogueStatus()
    {
        if (dialogueIterator.DialogueEnd)
        {
            minimap.IsMinimapUnlocked = true;
            textMapIsUnlocked.MapUnlocked();
            yield return null;
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(CheckDialogueStatus());
        }
    }
}
