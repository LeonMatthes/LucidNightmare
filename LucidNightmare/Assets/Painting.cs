using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public Movement player;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float alphaThreshold = (1.0f - (float)player.count / (float)player.PelletsCount) * 0.969f + 0.031f;
        Debug.Log(alphaThreshold);
        meshRenderer.materials[0].SetFloat("_Cutoff", alphaThreshold);
    }
}
