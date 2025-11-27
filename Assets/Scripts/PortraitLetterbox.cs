using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PortraitLetterbox : MonoBehaviour
{
    public float targetAspect = 9f / 16f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        UpdateCameraBox();
    }

    void Update()
    {
        UpdateCameraBox();
    }

    void UpdateCameraBox()
    {
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scale = windowAspect / targetAspect;

        if (scale < 1f)
        {
            cam.rect = new Rect(0, (1f - scale) / 2f, 1f, scale);
        }
        else
        {
            float scaleWidth = 1f / scale;
            cam.rect = new Rect((1f - scaleWidth) / 2f, 0, scaleWidth, 1f);
        }
    }
}
