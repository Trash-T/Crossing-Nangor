using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image timerbar;
    public float maxtime = 300f;
    float time;
   
    void Start()
    {
        timerbar = GetComponent<Image> ();
        time = maxtime;
        
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerbar.fillAmount = time / maxtime;
        }
        
    }
}
