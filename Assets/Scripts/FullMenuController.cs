using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMenuController : MonoBehaviour
{

    [SerializeField] Animator anim;


    [SerializeField] int setMouseHoverIndex = 1;
    public int SetMouseHoverIndex
    {
        get { return setMouseHoverIndex; }
        set { setMouseHoverIndex = value; }
    }
    [SerializeField] int setAnimIndex = 0;
    public int SetAnimIndex
    {
        get { return setAnimIndex; }
        set { setAnimIndex = value; }
    }

    IEnumerator AnimatorIndexController()
    {
        if (setMouseHoverIndex == setAnimIndex)
        {
            anim.SetInteger("whichHover", setAnimIndex);
        } else {
            anim.SetInteger("whichHover", 0);
        }

        yield return new WaitForEndOfFrame();
        StartCoroutine(AnimatorIndexController());
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimatorIndexController());
    }
}
