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

    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;

    [SerializeField] GameObject playerObj;

    [SerializeField] ButtonForScenes objectForSceneChange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (livesLeft <= 0)
        {
            objectForSceneChange.CallScene("GameOver");
        }

        if (playerObj.GetComponent<PlayerController>().InGround)
        {
            canTakeDamage = true;
        }

    }

    public void takesDamage()
    {

        if (canTakeDamage)
        {
            canTakeDamage = false;
            livesLeft -= 1;

            switch (livesLeft)
            {
                case 3:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(true);
                    break;
                case 2:
                    heart1.SetActive(true);
                    heart2.SetActive(true);
                    heart3.SetActive(false);
                    break;
                case 1:
                    heart1.SetActive(true);
                    heart2.SetActive(false);
                    heart3.SetActive(false);
                    break;
            }

        }

    }
}
