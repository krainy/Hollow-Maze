using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FadeOutText : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] int waitTime;

    void Start()
    {
        StartCoroutine(ToFadeOutText());
    }

    IEnumerator ToFadeOutText()
    {
        if (waitTime != 0)
        {
            yield return new WaitForSeconds((float)waitTime);
        }

        TMP_Text text = this.gameObject.GetComponent<TMP_Text>();

        if (time == 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }
        else
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                float alpha = i / time;

                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

                yield return new WaitForEndOfFrame();
            }

            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        }

        this.gameObject.SetActive(false);

        yield return null;
    }
}
