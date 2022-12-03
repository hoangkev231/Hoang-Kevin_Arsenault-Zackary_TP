using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3ePersonne : MonoBehaviour
{
    public GameObject subaruPoint;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Un plan rapproché avec un point de perspective éloigné donne une vue qui ressemble à celle de Gran Turismo.
        Vector3 positionFinale = subaruPoint.transform.TransformPoint(0, 1, -12);
        transform.position = Vector3.Lerp(transform.position, positionFinale, 0.2f);
        transform.LookAt(subaruPoint.transform);
    }
}
