using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image bar;
    public float maxTime = 300f;
    float time;
    public GameObject winScene;
    public GameObject darkMode;
    void Start()
    {
        winScene.SetActive(false);
        bar = GetComponent<Image> ();
        time = 0;
        AudioManager.instance.PlaySFX(14);
        
    }

    void Update()
    {
        if (time <= maxTime)
        {
            time += Time.deltaTime;
            bar.fillAmount = time / maxTime;
            if(time >= 180 && time <= 240)
            {
                darkMode.SetActive(true);
            }
            else
            {
                darkMode.SetActive(false);
            }
        }
        else
        {
            winScene.SetActive(true);
            AudioManager.instance.StopSFX(14);
        }
        
    }
}
