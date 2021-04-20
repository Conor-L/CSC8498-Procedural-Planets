using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetSettings : ScriptableObject
{
    public float planetRadius = 1.0f;

    [Range(4, 6)]
    public int planetSubdivisions = 4;

    [Header("Noise Settings")]
    public float noiseScale = 1.0f;
    public Vector3 noiseOffset = new Vector3(0, 0, 0);
    public float noiseContrast = 1.0f;
    public float displacementAmplitude = 1.0f;
}
