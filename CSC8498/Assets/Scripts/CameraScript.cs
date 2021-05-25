using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject planet;

    public PlanetSettings pSettings;

    void Update()
    {
        mainCamera.transform.LookAt(planet.transform);
        mainCamera.transform.position = new Vector3(0, 0, -pSettings.planetRadius * 3);
    }
    
}
