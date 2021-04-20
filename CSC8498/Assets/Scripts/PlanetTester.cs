using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlanetTester : MonoBehaviour
{
    public PlanetSettings planetSettings;
    public PlanetColourSettings colourSettings;
    MeshRenderer planetRenderer;

    string _Offset = "Vector3_f17d5aa95a654937b43ae21ceafc3b8c";
    string _Radius = "Vector1_d06b4fd444a0469ea7f737670fdb5507";

    [HideInInspector]
    public bool hideSettings;
    public bool updateSettings = true;

    public void CreatePlanet()
    {
        GetComponent<MeshFilter>().mesh = PlanetCreator.Create(planetSettings.planetSubdivisions, planetSettings.planetRadius);
        planetRenderer = GetComponent<MeshRenderer>();
        planetRenderer.sharedMaterial.color = colourSettings.planetColour;
    }

    public void OnPlanetSettingsUpdate()
    {        
        if (updateSettings == true)
        {
            CreatePlanet();
            planetRenderer.sharedMaterial.SetFloat(_Radius, planetSettings.planetRadius);
            planetRenderer.sharedMaterial.SetVector(_Offset, planetSettings.noiseOffset);
            Debug.Log(planetRenderer.sharedMaterial.GetVector(_Offset));
        }       
    }

    public void OnColourSettingsUpdate()
    {
        if (updateSettings == true)
        {
            CreatePlanet();
        }
    }

}
