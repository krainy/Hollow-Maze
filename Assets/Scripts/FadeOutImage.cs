using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{

    [SerializeField] int time;
    [SerializeField] int waitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToFadeOutImage());
    }

    IEnumerator ToFadeOutImage()
    {
        if (waitTime != 0)
        {
            yield return new WaitForSeconds((float)waitTime);
        }

        Image image = this.gameObject.GetComponent<Image>();

        if (time == 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
        else
        {
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                float alpha = i / time;

                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

                yield return new WaitForEndOfFrame();
            }
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }

        this.gameObject.SetActive(false);


        yield return null;
    }
}
