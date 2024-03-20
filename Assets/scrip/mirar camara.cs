using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraToTexture : MonoBehaviour
{
    public Camera mainCamera;
    public Renderer targetRenderer;

    private RenderTexture renderTexture;

    private void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;

        if (targetRenderer == null)
            targetRenderer = GetComponent<Renderer>();

        renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
        mainCamera.targetTexture = renderTexture;
        targetRenderer.material.mainTexture = renderTexture;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Apply ultrasound effect
        Graphics.Blit(source, destination, targetRenderer.material);
    }
}
