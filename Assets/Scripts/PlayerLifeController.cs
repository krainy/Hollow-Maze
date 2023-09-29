using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeController : MonoBehaviour
{

    [SerializeField] int livesLeft = 3;
    public int LivesLeft
    {
        set { livesLeft = value; }
        get { return livesLeft; }
    }
    [SerializeField] bool canTakeDamage = true;
    public bool CanTakeDamage
    {
        get { return canTakeDamage; }
        set { canTakeDamage = value; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (livesLeft <= 0)
        {
            ButtonForScenes.CallScene("GameOver");
        }
    }
}
