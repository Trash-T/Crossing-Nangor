using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount); //manggil singleton
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount); //manggil singleton
            Destroy(gameObject);
        }
    }
}
