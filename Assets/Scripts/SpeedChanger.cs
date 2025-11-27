using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    private float newSpeed;
    private float originalSpeed = 5;
    public float slowPercentage = 50;
    public bool canFreeze = false;
    public float cantMoveTime = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (canFreeze == true)
            {
                player.StartCoroutine(player.DisableMovement(cantMoveTime));
            }
            else
            {
                originalSpeed = player.movementSpeed;
                newSpeed = slowPercentage / 100 * originalSpeed; 
                player.movementSpeed = newSpeed;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            player.movementSpeed = originalSpeed;
        }
    }
}
