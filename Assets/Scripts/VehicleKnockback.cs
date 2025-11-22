using UnityEngine;

public class VehicleKnockback : MonoBehaviour
{
    public float knockbackForce = 20f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position += new Vector3(1f, 0) * knockbackForce * Time.deltaTime;
        }
    }
}
