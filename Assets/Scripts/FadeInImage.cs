using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] int waitTime;

    void Start()
    {
        StartCoroutine(ToFadeInImage());
    }

    IEnumerator ToFadeInImage()
    {
        if (waitTime != 0)
        {
            yield return new WaitForSeconds((float)waitTime);
        }

        Image image = this.gameObject.GetComponent<Image>();

        if (time == 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }
        else
        {
            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                float alpha = i / time;

                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

                yield return new WaitForEndOfFrame();
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
        }




        yield return null;
    }
}
