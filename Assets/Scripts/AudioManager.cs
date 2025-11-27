using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] allSFX;
    public static AudioManager instance;

    private void Awake() { 
        instance = this; 
    }

    public void PlaySFX(int i)
    {
        allSFX[i].Stop();
        allSFX[i].Play();
    }

    public void StopSFX(int i)
    {
        if (i >= 0 && i < allSFX.Length && allSFX[i] != null)
        {
            allSFX[i].Stop();
        }
    }
}
