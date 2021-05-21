using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunScript : MonoBehaviour
{

    public GameObject planet;
    public GameObject sun;
    public Light sunLight;
    private Vector3 rotation;

    [Header("Light Controls")]
    [Range(0.0f, 1.0f)]
    public float rotationSpeed = 0.00001f;

    // Update is called once per frame
    void Update()
    {
        sunLight.transform.LookAt(planet.transform);
        rotation = Quaternion.Euler(1, 0, 0) * Vector3.up * rotationSpeed;
        sun.transform.position = RotateAroundPoint(sun.transform.position, planet.transform.position, rotation);
    }
    Vector3 RotateAroundPoint(Vector3 p1, Vector3 p2, Vector3 a)
    {
        Vector3 dir = p1 - p2;
        dir = Quaternion.Euler(a) * dir;
        p1 = dir + p2;
        return p1;
    }
}
