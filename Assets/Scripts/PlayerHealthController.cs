using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance; //ini nmnya proses singleton biar script playerhealthcontroller gmpng diakses script lain
    public int currentHealth, maxHealth;
    public float invisibilityLength = 1f;
    private float invisibilityCounter; //invisibility length = durasi player invisible, invisibility counter = countdown player pas invisible
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
    public void DamagePlayer(int damage)
    {
        if(invisibilityCounter <= 0)
        {
            invisibilityCounter = invisibilityLength; 
            currentHealth -= damage;
            theSR.color = fadeColor;

            if(currentHealth <= 0)
            {
                PlayerDead();//roga mati
            }

        UpdateHealth();
        }
        
    }

    void UpdateHealth()
    {
        HealthController.instance.UpdateHealthDisplay(currentHealth);
    }

    public void AddHealth(int HealthAmount)
    {
        currentHealth += HealthAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UpdateHealth();
    }


    public void PlayerDead()
    {
        currentHealth = 0;
        // gameObject.SetActive(false);
        if (GameOverScene.instance != null)
        {
            GameOverScene.instance.PopUp(); 
            AudioManager.instance.PlaySFX(2);
        }
    }
}
