using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlanetTester : MonoBehaviour
{
    public PlanetSettings planetSettings;

    [HideInInspector]
    public bool hideSettings;

    public bool updateSettings = true;

    public void CreatePlanet()
    {
        GetComponent<MeshFilter>().mesh = PlanetCreator.Create(planetSettings.planetSubdivisions, planetSettings.planetRadius);
    }

    public void OnPlanetSettingsUpdate()
    {
        if (updateSettings == true)
        {
            CreatePlanet();
        }       
    }

}
