using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlanetSettings : ScriptableObject, IEquatable<PlanetSettings>
{
    public float planetRadius = 1.0f;

    [Range(4, 6)]
    public int planetSubdivisions = 4;

    [Header("Noise Settings")]
    public float noiseScale = 1.0f;
    public Vector3 noiseOffset = new Vector3(0, 0, 0);
    public float noiseContrast = 1.0f;
    public float displacementAmplitude = 1.0f;

    [Header("Mountain Noise Settings")]
    public float mountainHeight = 1.0f;

    public bool Equals(PlanetSettings other)
    {
        if (other == null)
        {
            return false;
        }

        if (other == this)
        {
            Debug.Log("WOAH");
            return true;
        }

        return (this.planetRadius == other.planetRadius && this.planetSubdivisions == other.planetSubdivisions &&
            this.noiseScale == other.noiseScale && this.noiseOffset == other.noiseOffset && this.noiseContrast == other.noiseContrast &&
            this.displacementAmplitude == other.displacementAmplitude && this.mountainHeight == other.mountainHeight);
    }

    public override int GetHashCode()
    {
        int hashCode = 1769261682;
        hashCode = hashCode * -1521134295 + planetRadius.GetHashCode();
        hashCode = hashCode * -1521134295 + planetSubdivisions.GetHashCode();
        hashCode = hashCode * -1521134295 + noiseScale.GetHashCode();
        hashCode = hashCode * -1521134295 + noiseOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + noiseContrast.GetHashCode();
        hashCode = hashCode * -1521134295 + displacementAmplitude.GetHashCode();
        hashCode = hashCode * -1521134295 + mountainHeight.GetHashCode();
        return hashCode;
    }
}
