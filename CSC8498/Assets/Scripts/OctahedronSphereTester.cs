using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
public class OctahedronSphereTester : MonoBehaviour
{
    public int subdivisions = 0;
    public float radius = 1.0f;

    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = OctahedronSphereCreator.Create(subdivisions, radius);
    }

}
