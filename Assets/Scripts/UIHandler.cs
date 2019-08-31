using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    // Configuration
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI headerText;
    [SerializeField] GameObject livesPanel;
    [SerializeField] RawImage[] livesImages;
    [SerializeField] AudioClip buttonSound;

    // State
    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void LateUpdate()
    {
        RefreshLivesDisplay();
        RefreshScoreDisplay();
    }

    private void RefreshScoreDisplay()
    {
        if (scoreText.gameObject.activeInHierarchy)
        {
            float score = gameSession.GetScore();
            scoreText.text = score.ToString();
        }
    }

    private void RefreshLivesDisplay()
    {
        if (livesPanel.activeInHierarchy)
        {
            int lives = gameSession.GetCurrentLives();
            int iterations = livesImages.Length;
            for (int i = 0; i < iterations; i++)
            {
                bool toDisplay = i < lives - 1;
                livesImages[i].enabled = toDisplay;
            }
        }
    }

    public void OnStartButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<GameSession>().ResetSession();
        sceneLoader.StartGame();
    }

    public void OnOptionsButtonPressed()
    {
        PlayButtonSound();
        sceneLoader.LoadOptions();
    }

    public void OnQuitButtonPressed()
    {
        PlayButtonSound();
        sceneLoader.Quit();
    }

    public void OnBackButtonPressed()
    {
        PlayButtonSound();
        sceneLoader.LoadMainMenu();
    }

    public void OnPlayAgainButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<GameSession>().ResetSession();
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

    private void PlayButtonSound()
    {
        AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);
    }
}
