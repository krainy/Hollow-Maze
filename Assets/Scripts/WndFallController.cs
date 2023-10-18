using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WndFallController : MonoBehaviour
{

    public void DestroyGameObject()
    {
        if (this.gameObject.name == "Wind1")
        {

            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
