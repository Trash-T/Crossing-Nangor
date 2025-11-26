using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    public AudioSource menuMusic;
    public AudioSource[] allSFX;

    public void PlayMenuMusic()
    {
        menuMusic.Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        allSFX[sfxToPlay].Stop();
        allSFX[sfxToPlay].Play();
    }
    public void StopSFX(int sfxToStop)
    {
        if (sfxToStop >= 0 && sfxToStop < allSFX.Length)
        {
   
            if (allSFX[sfxToStop] != null)
            {
                allSFX[sfxToStop].Stop();
            }
        }
    }
}