using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI headerText;
    [SerializeField] RawImage[] livesImages;

    // State
    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
        RefreshLivesDisplay();
    }

    private void LateUpdate()
    {
        RefreshLivesDisplay();
    }

    private void RefreshLivesDisplay()
    {
        if (livesImages != null && livesImages.Length > 0)
        {
            int lives = gameSession.GetCurrentLives();
            for (int i = 0; i < livesImages.Length; i++)
            {
                livesImages[i].gameObject.SetActive(i < lives - 1);
            }
        }
    }

    public void OnStartButtonPressed()
    {
        FindObjectOfType<GameSession>().Reset();
        sceneLoader.StartGame();
    }

    public void OnOptionsButtonPressed()
    {
        sceneLoader.LoadOptions();

    }

    public void OnQuitButtonPressed()
    {
        sceneLoader.Quit();
    }

    public void OnBackButtonPressed()
    {
        sceneLoader.LoadMainMenu();
    }

    public void OnPlayAgainButtonPressed()
    {
        FindObjectOfType<GameSession>().Reset();
        sceneLoader.StartGame();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateHeader(string header)
    {
        headerText.text = header;
    }

}
