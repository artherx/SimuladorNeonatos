using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videito : MonoBehaviour
{
    private VideoPlayer videos;
    public VideoClip[] videoC;
    public Veri veri;

    void Start()
    {
        videos = GetComponent<VideoPlayer>();
        if (!videos)
        {
            Debug.LogError("VideoPlayer component not found!");
        }
        if (veri == null)
        {
            Debug.LogError("Veri script not found!");
        }
    }

    void Update()
    {
        if (veri != null && veri.getCubo() > 0)
        {
            int tuki = veri.getCubo() - 1;
            Debug.Log("tuki es:"+tuki);
            if (tuki >= 0 && tuki < videoC.Length)
            {
                videos.clip = videoC[tuki];
                videos.Play();
            }
            else
            {
                Debug.LogWarning("Índice de cubo fuera de rango.");
            }
        }
    }
}
