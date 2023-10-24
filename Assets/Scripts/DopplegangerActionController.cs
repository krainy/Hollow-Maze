using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopplegangerActionController : MonoBehaviour
{
    [SerializeField] Levels WhichLevel;
    enum Levels
    {
        Water,
        EarthEasterEgg,
        Earth
    }

    [SerializeField] bool doppleOnlyOnce;
    bool hasDoppledOnlyOnce = false;
    bool canDopple = false;
    bool firstEntered = true;

    bool hasDoppled = false;
    bool canChange = false;
    Camera mainCamera;

    [SerializeField] GameObject inicialObject;
    [SerializeField] GameObject altObject;
    [SerializeField] GameObject noneGround;
    bool blockDopple = false;

    DopplegangerActionController thisScript;

    // Start is called before the first frame update
    void Start()
    {
        thisScript = GetComponent<DopplegangerActionController>();
        mainCamera = GameObject.Find("Auxiliar Camera").GetComponent<Camera>();

        if (WhichLevel == Levels.Water)
        {
            if (GameObject.Find("WaterLevel").GetComponent<WaterLevelController>().HasSeenWaterDissonance)
            {
                inicialObject.SetActive(false);
                altObject.SetActive(true);
                thisScript.enabled = false;
            }
            else
            {
                inicialObject.SetActive(true);
                altObject.SetActive(false);
            }
        }
        else if (WhichLevel == Levels.Earth)
        {
            if (inicialObject != altObject)
            {
                inicialObject.SetActive(true);
                altObject.SetActive(false);
            }
        }



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.Find("Rogerio").GetComponent<DEMOPlayerPowerup>().Element == 4)
        {
            blockDopple = true;
            inicialObject.SetActive(false);
            altObject.SetActive(false);
            noneGround.SetActive(true);
        }

        if (WhichLevel == Levels.Earth)
        {
            CheckCamera();
            if (canDopple && !hasDoppledOnlyOnce && !blockDopple)
            {
                bool isRotating = this.gameObject.GetComponentInParent<ScenarioController>().Rotating;
                if (canChange && !isRotating)
                {
                    if (ObjectAreInsideCameraBounds())
                    {
                        print("Entrou na tela");
                        hasDoppled = false;

                        inicialObject.SetActive(false);
                        altObject.SetActive(true);

                        GameObject aux = altObject;
                        altObject = inicialObject;
                        inicialObject = aux;

                        if (doppleOnlyOnce)
                        {
                            hasDoppledOnlyOnce = true;
                        }

                        canChange = false;
                    }

                }
                else
                {

                    if (ObjectAreInsideCameraBounds() == false)
                    {
                        canChange = true;
                    }
                }
            }
        }
        else if (WhichLevel == Levels.EarthEasterEgg)
        {
            if (canDopple && !hasDoppledOnlyOnce)
            {
                if (canChange)
                {
                    if (ObjectAreInsideCameraBounds())
                    {
                        print("Entrou na tela");
                        canDopple = false;

                        inicialObject.SetActive(false);
                        altObject.SetActive(true);

                        GameObject aux = altObject;
                        altObject = inicialObject;
                        inicialObject = aux;

                        if (doppleOnlyOnce)
                        {
                            hasDoppledOnlyOnce = true;
                        }

                        canChange = false;
                    }

                }
            }
        }
    }

    bool ObjectAreInsideCameraBounds()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.gameObject.GetComponent<Transform>().position);
        if (viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1)
        {
            if (!canDopple && firstEntered)
            {
                firstEntered = false;
                canDopple = true;
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    void CheckCamera()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.gameObject.GetComponent<Transform>().position);
        if (viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1)
        {
            if (!canDopple) canDopple = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (WhichLevel == Levels.Water)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (!hasDoppled)
                {
                    hasDoppled = true;
                    GameObject.Find("WaterLevel").GetComponent<WaterLevelController>().HasSeenWaterDissonance = true;
                    inicialObject.SetActive(false);
                    altObject.SetActive(true);
                    thisScript.enabled = false;
                }
            }
        }
        else if (WhichLevel == Levels.EarthEasterEgg)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                canDopple = true;
            }

        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (WhichLevel == Levels.EarthEasterEgg)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                StartCoroutine(ChangeCoroutine());
            }

        }
    }

    IEnumerator ChangeCoroutine()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(this.gameObject.GetComponent<Transform>().position);
        if (!(viewPos.x > 0 && viewPos.y > 0 && viewPos.x < 1 && viewPos.y < 1))
        {
            canChange = true;
        }
        else
        {
            yield return new WaitForEndOfFrame();
            StartCoroutine(ChangeCoroutine());
        }

    }
}
