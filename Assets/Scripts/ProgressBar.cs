using Unity.VisualScripting;
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
        time = maxTime;
        
    }

    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            bar.fillAmount = time / maxTime;
        }
        
    }
}
