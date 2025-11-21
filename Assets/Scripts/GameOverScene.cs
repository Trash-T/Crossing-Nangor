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
        StartCoroutine(PopUpCoroutine());
    }
    IEnumerator PopUpCoroutine()
    {
        yield return new WaitForSeconds(_popUpDelay);
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void SetMessage(string s)
    {
        message.text = s; 
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR 
    UnityEditor.EditorApplication.isPlaying = false;
    message.enabled = false;
#endif
    }
}