using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Camera mainCamera;
    public GameObject planet;

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.LookAt(planet.transform);
    }

    
}
