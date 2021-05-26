using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject planet;

    public PlanetSettings pSettings;
    private int hashCode;
    private Vector3 currentPosition;

    private float t = 0.0f;

    private void Start()
    {
        hashCode = pSettings.GetHashCode();        
        mainCamera.transform.LookAt(planet.transform);
        mainCamera.transform.position = new Vector3(0, 0, -pSettings.planetRadius * 3);
        currentPosition = mainCamera.transform.position;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (hashCode != pSettings.GetHashCode())
        {
            mainCamera.transform.LookAt(planet.transform);
            mainCamera.transform.position = Vector3.Lerp(currentPosition, new Vector3(0, 0, -pSettings.planetRadius * 3), t);
            hashCode = pSettings.GetHashCode();
            currentPosition = mainCamera.transform.position;
        }
    }
    
}
