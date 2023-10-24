using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUnlockedText : MonoBehaviour
{
    [SerializeField] GameObject MapUnlockerText;
    [SerializeField] AudioSource mapIsUnlocked;
    
    IEnumerator MapUnlockedTextReveal(){
        for(float i = MapUnlockerText.GetComponent<RectTransform>().anchoredPosition.y; i < -340; i += 50f * Time.deltaTime){
            MapUnlockerText.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, i, 0f);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    public void MapUnlocked(){
        StartCoroutine(MapUnlockedTextReveal());
        mapIsUnlocked.Play();
    }
}
