using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlanetTester : MonoBehaviour
{
    public PlanetSettings planetSettings;
    public PlanetColourSettings colourSettings;
    MeshRenderer planetRenderer;

    // Shader properties for noise/planet
    string noiseScale = "Vector1_a194992c1fe14c7ba013fa8c60816c3e";
    string noiseOffset = "Vector3_f17d5aa95a654937b43ae21ceafc3b8c";
    string planetRadius = "Vector1_d06b4fd444a0469ea7f737670fdb5507";
    string noiseContrast = "Vector1_f07c96f6112c48d18ade235f3c5330c0";
    string displacementAmplitude = "Vector1_6123ea63b5d3436d85f33428059b122a";

    // Shader property for colour/graphics
    string hueOffset = "Vector1_098be1435dd945e3b45c18bb3146ab15";
    string ambientOcculsion = "Vector1_69d143d58eb6407595a4c6dcc94c84c2";
    string landscapeGradient = "Gradient_e03390dd776d4958882711d82acb0070";

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
            planetRenderer.sharedMaterial.SetFloat(noiseScale, planetSettings.noiseScale);
            planetRenderer.sharedMaterial.SetVector(noiseOffset, planetSettings.noiseOffset);
            planetRenderer.sharedMaterial.SetFloat(planetRadius, planetSettings.planetRadius);            
            planetRenderer.sharedMaterial.SetFloat(noiseContrast, planetSettings.noiseContrast);
            planetRenderer.sharedMaterial.SetFloat(displacementAmplitude, planetSettings.displacementAmplitude);
        }       
    }

    public void OnColourSettingsUpdate()
    {
        if (updateSettings == true)
        {
            CreatePlanet();
            planetRenderer.sharedMaterial.SetFloat(hueOffset, colourSettings.hueOffset);
            planetRenderer.sharedMaterial.SetFloat(ambientOcculsion, colourSettings.ambientOcculsion);
        }
    }

}
