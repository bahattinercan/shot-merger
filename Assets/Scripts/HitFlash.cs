using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFlash : MonoBehaviour
{
    private readonly List<Color> originalColors = new List<Color>();

    private int originalColorIndex;

    public bool useEmission;

    private void Start()
    {
        // Find all the children of the GameObject with MeshRenderers

        MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();

        // Cycle through each child object found with a MeshRenderer

        foreach (MeshRenderer rend in children)
        {
            // And for each child, cycle through each material

            foreach (Material mat in rend.materials)
            {
                if (useEmission)
                {
                    // Enable Keyword EMISSION for each material

                    mat.EnableKeyword("_EMISSION");
                }
                else
                {
                    // Store original colors

                    originalColors.Add(mat.color);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            StartCoroutine("Flash");
        }
    }

    public IEnumerator Flash()
    {
        // Flash color

        MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer rend in children)
        {
            foreach (Material mat in rend.materials)
            {
                if (useEmission)
                    mat.SetColor("_EmissionColor", Color.white);
                else
                    mat.SetColor("_Color", Color.white);
            }
        }

        yield return new WaitForSeconds(0.1f);

        // Restore default colors or emission

        foreach (MeshRenderer rend in children)
        {
            foreach (Material mat in rend.materials)
            {
                if (useEmission)
                    mat.SetColor("_EmissionColor", Color.black);
                else
                {
                    mat.SetColor("_Color", originalColors[originalColorIndex]);

                    // Increment originalColorIndex by 1

                    originalColorIndex += 1;
                }
            }
        }

        if (useEmission)
            StopCoroutine("Flash");
        else
        {
            // Reset originalColorIndex

            originalColorIndex = 0;

            StopCoroutine("Flash");
        }
    }
}