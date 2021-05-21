using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{

    public GameObject planet;

    [Header("Rotation Controls")]
    [Range(0, 1)]
    public float rotationSpeed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        planet.transform.Rotate(rotationSpeed, rotationSpeed, rotationSpeed/10);
    }
}
