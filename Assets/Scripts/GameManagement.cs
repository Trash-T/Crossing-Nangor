using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static GameManagement Instance;
    public GameOverScene gameOverScene;
    public int enemiesCount = 0;


    void Awake()
    {
        Instance = this;
    }

    public void Win()
    {
        gameOverScene.PopUp();
        gameOverScene.SetMessage("You win!\nI guess...");
    }

    public void Lose()
    {
        gameOverScene.PopUp();
        gameOverScene.SetMessage("You died!\nCan't win anyway");
        

    }
}
