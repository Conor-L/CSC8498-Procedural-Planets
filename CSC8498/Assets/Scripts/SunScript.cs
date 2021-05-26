using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunScript : MonoBehaviour
{

    public GameObject planet;
    public GameObject sun;
    public Camera mainCamera;
    public Light sunLight;

    // UI
    public Toggle lockSunToggle;
    public Button defaultPositionBtn;
    public Slider orbitSpeed;

    private Vector3 rotation;

    [Header("Light Controls")]
    [Range(0.0f, 1.0f)]
    public float rotationSpeed = 0.1f;

    void Start()
    {
        defaultPositionBtn.onClick.AddListener(ReturnToDefaultPosition);
    }

    void FixedUpdate()
    {
        sunLight.transform.LookAt(planet.transform);       

        if (lockSunToggle.isOn == true)
        {
            sun.transform.position = new Vector3(0, 0, -50000);
        }

        else
        {
            rotation = Quaternion.Euler(1, 0, 0) * Vector3.up * orbitSpeed.value;
            sun.transform.position = RotateAroundPoint(sun.transform.position, planet.transform.position, rotation);
        }

    }
    Vector3 RotateAroundPoint(Vector3 p1, Vector3 p2, Vector3 a)
    {
        Vector3 dir = p1 - p2;
        dir = Quaternion.Euler(a) * dir;
        p1 = dir + p2;
        return p1;
    }

    void ReturnToDefaultPosition()
    {
        if (lockSunToggle.isOn == false)
        {
            sun.transform.position = new Vector3(25000, 0, 0);
        }
    }
}
