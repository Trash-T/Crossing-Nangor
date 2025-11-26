using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScene : MonoBehaviour
{
    private float _popUpDelay = 1.5f;
    private CanvasGroup _canvasGroup;
    public TextMeshProUGUI message;
    public static GameOverScene instance { get; private set; }
    public GameObject player;
    public Sprite playerDieUp;
    public Sprite playerDieDown;
    public Sprite playerDieLeft;
    public Sprite playerDieRight;

 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void PopUp()
    {
        Animator anim = player.GetComponent<Animator>();
        if (anim != null) anim.enabled = false;
        var dir = player.GetComponent<PlayerMovement>().lastDirection;

        switch(dir)
        {
            case PlayerMovement.PlayerDirection.Up:
                player.GetComponent<SpriteRenderer>().sprite = playerDieUp;
                break;

            case PlayerMovement.PlayerDirection.Down:
                player.GetComponent<SpriteRenderer>().sprite = playerDieDown;
                break;

            case PlayerMovement.PlayerDirection.Left:
                player.GetComponent<SpriteRenderer>().sprite = playerDieLeft;
                break;

            case PlayerMovement.PlayerDirection.Right:
                player.GetComponent<SpriteRenderer>().sprite = playerDieLeft;
                break;
        }

        Time.timeScale = 0f;
        StartCoroutine(PopUpCoroutine());
    }
    IEnumerator PopUpCoroutine()
    {
        yield return new WaitForSecondsRealtime(_popUpDelay);
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        AudioManager.instance.PlaySFX(3);
    }

    public void SetMessage(string s)
    {
        message.text = s; 
    }
    public void Restart()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;

        Time.timeScale = 1f;
        Application.Quit();

#if UNITY_EDITOR 
    UnityEditor.EditorApplication.isPlaying = false;
    message.enabled = false;
#endif
    }
}