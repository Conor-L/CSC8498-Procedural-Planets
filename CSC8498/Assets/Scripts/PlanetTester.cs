using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlanetTester : MonoBehaviour
{
    public PlanetSettings planetSettings;
    public PlanetColourSettings colourSettings;
    MeshRenderer planetRenderer;

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

            // Set Shader properties whenever the settings are changed
            planetRenderer.sharedMaterial.SetFloat("noiseScale", planetSettings.noiseScale);
            planetRenderer.sharedMaterial.SetVector("noiseOffset", planetSettings.noiseOffset);
            planetRenderer.sharedMaterial.SetFloat("planetRadius", planetSettings.planetRadius);            
            planetRenderer.sharedMaterial.SetFloat("noiseContrast", planetSettings.noiseContrast);
            planetRenderer.sharedMaterial.SetFloat("displacementAmplitude", planetSettings.displacementAmplitude);

            // Mountain Noise
            planetRenderer.sharedMaterial.SetFloat("mountainHeight", planetSettings.mountainHeight);

            // Steepness
            planetRenderer.sharedMaterial.SetFloat("testAngle", planetSettings.testAngle);
        }       
    }

    public void OnColourSettingsUpdate()
    {
        if (updateSettings == true)
        {
            CreatePlanet();
            planetRenderer.sharedMaterial.SetFloat("hueOffset", colourSettings.hueOffset);
            planetRenderer.sharedMaterial.SetFloat("ambientOcculsion", colourSettings.ambientOcculsion);

            planetRenderer.sharedMaterial.SetFloat("normalScale", colourSettings.triplanarScale);
            planetRenderer.sharedMaterial.SetFloat("normalSharpness", colourSettings.triplanarSharpness);

            planetRenderer.sharedMaterial.SetFloat("triplanarScale", colourSettings.triplanarScale);
            planetRenderer.sharedMaterial.SetFloat("triplanarSharpness", colourSettings.triplanarSharpness);
                       
        }
    }

}
