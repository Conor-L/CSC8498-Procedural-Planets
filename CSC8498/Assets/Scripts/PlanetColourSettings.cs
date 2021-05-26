using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class PlanetColourSettings : ScriptableObject, IEquatable<PlanetColourSettings> {
    public Color planetColour;

    [Header("Graphics Settings (shader)")]
    public float hueOffset = 0.0f;
    public float ambientOcculsion = 1.0f;

    [Header("Triplanar Mapping Settings")]
    public float triplanarScale = 1.0f;
    public float triplanarSharpness = 1.0f;

    public bool Equals(PlanetColourSettings other)
    {
        if (other == this)
        {
            return true;
        }

        if (other == null)
        {
            return false;
        }

        return false;
    }

    public override int GetHashCode()
    {
        int hashCode = -1690326858;
        hashCode = hashCode * -1521134295 + planetColour.GetHashCode();
        hashCode = hashCode * -1521134295 + hueOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + ambientOcculsion.GetHashCode();
        hashCode = hashCode * -1521134295 + triplanarScale.GetHashCode();
        hashCode = hashCode * -1521134295 + triplanarSharpness.GetHashCode();
        return hashCode;
    }
}
