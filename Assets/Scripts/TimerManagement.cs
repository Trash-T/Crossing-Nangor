using UnityEngine;
using TMPro;
public class TimerManagement : MonoBehaviour
{
    private float TimeCount;
    [SerializeField] private TMP_Text TimerTxt;
    private int minutes, seconds;
    private void Update()
    {
        TimeCount += Time.deltaTime;
        minutes = (int)(TimeCount / 60f);
        seconds = (int)(TimeCount - minutes * 60f);
        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
