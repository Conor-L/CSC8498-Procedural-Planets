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
    private string noiseScale = "Vector1_a194992c1fe14c7ba013fa8c60816c3e";
    private string noiseOffset = "Vector3_f17d5aa95a654937b43ae21ceafc3b8c";
    private string planetRadius = "Vector1_d06b4fd444a0469ea7f737670fdb5507";
    private string noiseContrast = "Vector1_f07c96f6112c48d18ade235f3c5330c0";
    private string displacementAmplitude = "Vector1_6123ea63b5d3436d85f33428059b122a";
    private string mountainHeight = "Vector1_2b100e2524f14ed386d7a532ec915ab4";

    // Shader property for colour/graphics
    private string hueOffset = "Vector1_098be1435dd945e3b45c18bb3146ab15";
    private string ambientOcculsion = "Vector1_69d143d58eb6407595a4c6dcc94c84c2";

    // Triplanar Mapping
    private string triplanarSharpness = "Vector1_32160d8f0aa54c658ed62e8bb0bdc84f";
    private string triplanarScale = "Vector1_9a1b8ffce7914b489be885ada655f11a";

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

            // Mountain Noise
            planetRenderer.sharedMaterial.SetFloat(mountainHeight, planetSettings.mountainHeight);
        }       
    }

    public void OnColourSettingsUpdate()
    {
        if (updateSettings == true)
        {
            CreatePlanet();
            planetRenderer.sharedMaterial.SetFloat(hueOffset, colourSettings.hueOffset);
            planetRenderer.sharedMaterial.SetFloat(ambientOcculsion, colourSettings.ambientOcculsion);
            planetRenderer.sharedMaterial.SetFloat(triplanarSharpness, colourSettings.triplanarSharpness);
            planetRenderer.sharedMaterial.SetFloat(triplanarScale, colourSettings.triplanarScale);
        }
    }

}
