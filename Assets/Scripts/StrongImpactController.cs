using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongImpactController : MonoBehaviour
{

    [SerializeField] Transform airFlowTransform;
    [SerializeField] GameObject airFlowPrefab;

    public void StrongImpact()
    {
        Instantiate(airFlowPrefab, airFlowTransform.position, Quaternion.identity);
    }
}
