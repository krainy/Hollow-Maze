using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    [SerializeField] private int minsTime = 0;
    [SerializeField] float secsTime = 0;

    string minsText;
    string secsText;
 
    private void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
 
 
        m_TextComponent.text = "00:00";
    }

    void FixedUpdate(){
        secsTime += Time.deltaTime;

        if(secsTime >= 60){
            secsTime -= 60;
            minsTime += 1;
        }

        if(Mathf.FloorToInt(secsTime) < 10){
            secsText = "0" + Mathf.FloorToInt(secsTime).ToString();
        } else {
            secsText = Mathf.FloorToInt(secsTime).ToString();
    }
        
        if(Mathf.FloorToInt(minsTime) < 10){
            minsText = "0" + Mathf.FloorToInt(minsTime).ToString();
        } else {
            minsText = Mathf.FloorToInt(minsTime).ToString();
        }

        m_TextComponent.text = minsText + ":" + secsText;
    }
}
