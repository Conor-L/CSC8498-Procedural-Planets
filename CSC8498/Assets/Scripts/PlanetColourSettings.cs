using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetColourSettings : ScriptableObject {
    public Color planetColour;

    [Header("Graphics Settings (shader)")]
    public float hueOffset = 0.0f;
    public float ambientOcculsion = 1.0f;
}