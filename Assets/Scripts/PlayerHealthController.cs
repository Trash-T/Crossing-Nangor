using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; //ini nmnya proses singleton biar script playerhealthcontroller gmpng diakses script lain
    public int currentHealth, maxHealth;
    public float invisibilityLength = 1f;
    private float invisibilityCounter;
    public SpriteRenderer theSR;
    public Color normalColor, fadeColor;
  
    private void Awake()
    {
        instance = this;
    } 
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth();
    }

    void Update()
    {
        if(invisibilityCounter>0)
        {
            invisibilityCounter -= Time.deltaTime;
        }
        if(invisibilityCounter <= 0)
        {
            theSR.color = normalColor;
        }
       
    }
    public void DamagePlayer()
    {
        if(invisibilityCounter <= 0)
        {
            invisibilityCounter = invisibilityLength;
            currentHealth += -1;
            theSR.color = fadeColor;

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false); //roga mati
            }

        UpdateHealth();
        }
        
    }

    void UpdateHealth()
    {
        HealthController.instance.UpdateHealthDisplay(currentHealth);
    }
}
