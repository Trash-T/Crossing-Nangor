using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3;
    [ReadOnly] public Vector3 movementDirection;

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        // Update position
        transform.position += movementSpeed * Time.fixedDeltaTime * movementDirection;

        // Update orientation
        if (movementDirection.x > 0 && transform.localScale.x < 0 || movementDirection.x < 0 && transform.localScale.x > 0)
        {
            // Flip
            transform.localScale = new(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void ReadInput()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            moveY++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX--;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX++;
        }

        movementDirection = new Vector2(moveX, moveY).normalized;
    }
}