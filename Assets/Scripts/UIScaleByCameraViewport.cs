using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class UIScaleByCameraViewport : MonoBehaviour
{
    public Vector2 referenceResolution = new Vector2(1080, 1920);
    private Canvas canvas;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        Rect view = Camera.main.pixelRect;

        float scaleX = view.width / referenceResolution.x;
        float scaleY = view.height / referenceResolution.y;

        float scale = Mathf.Min(scaleX, scaleY); // keep aspect ratio

        canvas.scaleFactor = scale;

        
    }
}
