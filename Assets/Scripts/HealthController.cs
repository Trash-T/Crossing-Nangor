using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour //UIcontroller
{
    public Image[] heartIcons;
    public static HealthController instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthDisplay(int health)
    {
        for(int i=0 ; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;

            if(health <= i)
            {
               heartIcons[i].enabled = false; 
            }
        }
    }
}
