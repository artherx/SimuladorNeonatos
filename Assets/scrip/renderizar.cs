using UnityEngine;
using UnityEngine.Video;

public class remderizar : MonoBehaviour
{
    public VideoPlayer videoPlayer1; // Referencia al VideoPlayer del primer plano
    private Renderer myRenderer; // Renderer del segundo plano

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        if (myRenderer == null)
        {
            Debug.LogError("Renderer component not found!");
            return;
        }

        if (videoPlayer1 == null)
        {
            Debug.LogError("VideoPlayer1 reference not set!");
            return;
        }

    }
    private void Update() {
        
        myRenderer.material.mainTexture = videoPlayer1.texture;
    }
}
