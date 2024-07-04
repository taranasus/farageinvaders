using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetMaterialTile : MonoBehaviour
{
    private Material material;
    private float[] xOffsets = { 0f, 0.33333f, 0.66666f };
    private float[] yOffsets = { 0f, 0.5f };

    // Start is called before the first frame update
    void Start()
    {
        // Get the material attached to the renderer
        material = GetComponent<Renderer>().material;

        // Set a random offset at the start
        SetRandomOffset();
    }

    // Update is called once per frame
    void Update()
    {
        // Optionally, you can continuously update the offset or based on a condition
        // For example, uncomment the following line to update every frame:
        // SetRandomOffset();
    }

    void SetRandomOffset()
    {
        // Randomly select values from the predefined arrays
        float randomX = xOffsets[Random.Range(0, xOffsets.Length)];
        float randomY = yOffsets[Random.Range(0, yOffsets.Length)];

        // Set the material's texture offset
        material.mainTextureOffset = new Vector2(randomX, randomY);
    }
}