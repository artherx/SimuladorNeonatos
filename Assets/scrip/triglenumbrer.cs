using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triglenumbrer : MonoBehaviour
{
    public TMP_Text displayText;
    public Camera mainCamera;

    void Start()
    {
        displayText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        int trianglesCount = 0;

        // Obtener todos los objetos renderizados por la cámara
        Renderer[] renderers = FindObjectsOfType<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            // Comprobar si el objeto es visible por la cámara
            if (renderer.isVisible)
            {
                // Obtener el Mesh asociado al objeto
                MeshFilter meshFilter = renderer.GetComponent<MeshFilter>();
                SkinnedMeshRenderer skinnedMeshRenderer = renderer.GetComponent<SkinnedMeshRenderer>();

                if (meshFilter != null)
                {
                    // Contar los triángulos del Mesh
                    trianglesCount += meshFilter.sharedMesh.triangles.Length / 3;
                }
                else if (skinnedMeshRenderer != null)
                {
                    // Contar los triángulos del SkinnedMeshRenderer
                    trianglesCount += skinnedMeshRenderer.sharedMesh.triangles.Length / 3;
                }
            }
        }

        displayText.text = "Triangles Count: " + trianglesCount.ToString();
    }
}

