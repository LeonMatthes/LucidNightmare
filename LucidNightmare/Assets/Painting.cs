using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Movement player;

    float alphaThreshold = 1;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        //alphaThreshold = player.;
        material.SetFloat("_Cutoff", alphaThreshold);
    }
}
