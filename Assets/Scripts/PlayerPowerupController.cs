using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerupController : MonoBehaviour
{

    [SerializeField] PlayerLifeController playerLife;

    [SerializeField] bool hasPowerup = false;
    public bool HasPowerUp
    {
        set { hasPowerup = value; }
    }
    [SerializeField] bool canGetPowerUp = true;


    /*
            0 = Nenhum
            1 = Fogo
            2 = Vento
            3 = Agua
            4 = Terra
        */
    [SerializeField] int element = 0;
    public int Element
    {
        get { return element; }
        set { element = value; }
    }

    IEnumerator SetPowerup()
    {
        Debug.Log("Setting power up");
        if (hasPowerup && canGetPowerUp)
        {
            canGetPowerUp = false;
            StartCoroutine(getDamaged());
            StartCoroutine(powerUp());
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(SetPowerup());
        }
    }

    IEnumerator powerUp()
    {

        /*
            1 = Fogo
            2 = Vento
            3 = Agua
            4 = Terra
        */
        int randomElement = Mathf.FloorToInt(Random.Range(1, 4.9f));
        Debug.Log("Tudo bem ate aqui");
        Debug.Log(randomElement);

        switch (randomElement)
        {
            case 1:
                //fogo
                element = randomElement;

                yield return null;
                break;
            case 2:

                yield return null;
                break;
            case 3:
                element = randomElement;

                yield return null;
                break;
            case 4:
                element = randomElement;

                yield return null;
                break;
            default:
                Debug.Log("Tem parada errada ai");
                yield return null;
                break;
        }


    }

    IEnumerator getDamaged()
    {
        yield return new WaitForSeconds(10f);
        playerLife.LivesLeft -= 1;
        canGetPowerUp = true;
        hasPowerup = false;
        element = 0;
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetPowerup());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UsedElement()
    {
        element = 0;
        StopAllCoroutines();
        StartCoroutine(SetPowerup());
    }
}
