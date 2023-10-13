using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMenuController : MonoBehaviour
{

    [SerializeField] int setAnimIndex = 0;
    [SerializeField] Animator anim;
    public int SetAnimIndex
    {
        get { return setAnimIndex; }
        set { setAnimIndex = value; }
    }

    IEnumerator AnimatorIndexController(){
        anim.SetInteger("whichHover", setAnimIndex);
        yield return new WaitForEndOfFrame();
        StartCoroutine(AnimatorIndexController());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimatorIndexController());
    }
}
