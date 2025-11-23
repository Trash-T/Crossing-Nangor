using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image bar;
    public float maxTime = 300f;
    float time;
   
    void Start()
    {
        bar = GetComponent<Image> ();
        time = 0;
        
    }

    void Update()
    {
        if (time <= maxTime)
        {
            time += Time.deltaTime;
            bar.fillAmount = time / maxTime;
        }
        
    }
}
