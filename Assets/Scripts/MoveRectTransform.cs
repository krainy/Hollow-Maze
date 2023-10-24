using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRectTransform : MonoBehaviour
{

    [SerializeField] Vector2 endOfRectTransform;
    [SerializeField] float rectTransformTime;
    Vector2 initialRectTransformPosition;


    IEnumerator MovingRectTransform()
    {
        RectTransform gameObjectRectTransform = this.gameObject.GetComponent<RectTransform>();

        for (float i = 0; i <= rectTransformTime; i += Time.deltaTime)
        {
            float x = ((i / rectTransformTime) * (endOfRectTransform.x - initialRectTransformPosition.x)) + initialRectTransformPosition.x;
            float y = ((i / rectTransformTime) * (endOfRectTransform.y - initialRectTransformPosition.y)) + initialRectTransformPosition.y;

            gameObjectRectTransform.anchoredPosition = new Vector2(x, y);

            yield return new WaitForEndOfFrame();
        }

        yield return null;

    }

    void Start()
    {
        initialRectTransformPosition = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
        StartCoroutine(MovingRectTransform());
    }
}
