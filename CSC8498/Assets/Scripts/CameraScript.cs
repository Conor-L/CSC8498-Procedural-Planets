using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject planet;

    void Update()
    {
        mainCamera.transform.LookAt(planet.transform);
    }

    
}
