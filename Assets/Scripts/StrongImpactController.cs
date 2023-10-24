using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongImpactController : MonoBehaviour
{

    [SerializeField] Transform airFlowTransform;
    [SerializeField] GameObject airFlowPrefab;
    [SerializeField] AudioSource fallSFX;

    public void StrongImpact()
    {
        Instantiate(airFlowPrefab, airFlowTransform.position, Quaternion.identity);
        fallSFX.Play();
    }
}
