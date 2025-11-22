using UnityEngine;
using UnityEngine.UI;

public class TimerManagement : MonoBehaviour
{
    private float timeCount;
    [SerializeField] private Text timerText;
    private int minutes, seconds;

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        minutes = (int)(timeCount / 60f);
        seconds = (int)(timeCount - minutes * 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
