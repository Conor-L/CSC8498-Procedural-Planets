using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementControl : MonoBehaviour
{
    public float displacementAmount = 1000;
    MeshRenderer meshRender;

    private void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        displacementAmount = Mathf.Lerp(displacementAmount, 0, Time.deltaTime);
        meshRender.material.SetFloat("_Amount", displacementAmount);
    }
}
