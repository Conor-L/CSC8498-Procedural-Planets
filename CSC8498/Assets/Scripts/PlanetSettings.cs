using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetSettings : ScriptableObject
{
    public float planetRadius = 1.0f;

    [Range(4, 6)]
    public int planetSubdivisions = 4;
}
