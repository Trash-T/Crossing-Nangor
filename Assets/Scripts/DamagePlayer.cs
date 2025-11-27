using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageAmount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount); //manggil singleton
            AudioManager.instance.PlaySFX(15);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealthController.instance.DamagePlayer(damageAmount); //manggil singleton
            AudioManager.instance.PlaySFX(15);

            if (!gameObject.CompareTag("Hole"))
            {
                Destroy(gameObject);
            }           
        }
    }
}
