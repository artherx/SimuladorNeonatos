using UnityEngine;
using TMPro;

public class fpsowo : MonoBehaviour
{
    public TMP_Text displayText;
    private float deltaTime = 0.0f;

    void Start()
    {
        displayText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        displayText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
