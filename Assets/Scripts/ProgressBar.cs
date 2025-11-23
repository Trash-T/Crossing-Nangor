using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    Image bar;
    public float maxTime = 300f;
    float time;
    public GameObject winScene;
    void Start()
    {
        winScene.SetActive(false);
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
        else
        {
            winScene.SetActive(true);
        }
        
    }
}
