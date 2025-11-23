using UnityEngine;

public class LerpMovementUI : MonoBehaviour
{
    public float maxTime = 10f; // Durasi total pergerakan
    private float currentTime = 0f;
    public float startX = -260f; 
    public float endX = 260f;
    private RectTransform rectTransform; 
    private float initialY;
    private float initialZ;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); 
        initialY = rectTransform.localPosition.y;
        initialZ = rectTransform.localPosition.z;
        Vector3 initialPosition = new Vector3(startX, initialY, initialZ);
        rectTransform.localPosition = initialPosition;    
        currentTime = 0f;
    }

    void Update()
    {
        if (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;
            float ratio = Mathf.Clamp01(currentTime / maxTime);
            float newX = Mathf.Lerp(startX, endX, ratio);
            Vector3 newPosition = new Vector3(newX, initialY, initialZ);
            rectTransform.localPosition = newPosition; 
        }
    }
}