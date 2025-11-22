using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float movementSpeed = 1.5f;
    public float deadZone = -15f;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * movementSpeed * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}

// Camera 9.59
// road -8.5, 0.75
// bg spawner 12.54