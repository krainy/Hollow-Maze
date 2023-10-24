using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreditsController : MonoBehaviour
{

    [SerializeField] Vector3 endOfCreditTransform;
    [SerializeField] GameObject[] objects;
    [SerializeField] int[] timeBetweenObjects;


    IEnumerator ActivateCreditsObjects()
    {
        int index = 0;

        foreach (GameObject g in objects)
        {
            yield return new WaitForSeconds((float)timeBetweenObjects[index]);

            g.SetActive(true);
            index++;
        }

        yield return null;
    }

    void Start()
    {
        StartCoroutine(ActivateCreditsObjects());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
