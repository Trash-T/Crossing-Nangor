using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; //ini nmnya proses singleton biar script playerhealthcontroller gmpng diakses script lain
    public int currentHealth, maxHealth;
  
    private void Awake()
    {
        instance = this;
    } 
    void Start()
    {
        currentHealth = maxHealth;
        HealthController.instance.UpdateHealthDisplay(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer()
    {
        currentHealth += -1;

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false); //roga mati
        }

        HealthController.instance.UpdateHealthDisplay(currentHealth);
    }
}
