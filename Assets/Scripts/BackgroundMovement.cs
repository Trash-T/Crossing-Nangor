using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float movementSpeed = 1f;
    private float deadZone = -22f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * movementSpeed * Time.deltaTime;
        AudioManager.instance.PlaySFX(9);
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
            
        }
        
    }
}