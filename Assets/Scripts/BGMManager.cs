using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager instance;
    public AudioSource menuMusic;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if (!menuMusic.isPlaying)
            menuMusic.Play();
    }

    public void PlayMenuMusic()
    {
        if (!menuMusic.isPlaying)
            menuMusic.Play();
    }
}
