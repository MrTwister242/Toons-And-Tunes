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


    private void LateUpdate()
    {
        RefreshLivesDisplay();
        RefreshScoreDisplay();
    }

    private void RefreshScoreDisplay()
    {

        if (scoreText.gameObject.activeInHierarchy)
        {
            float score = FindObjectOfType<GameSession>().GetScore();
            scoreText.text = score.ToString();
        }
    }

    private void RefreshLivesDisplay()
    {
        if (livesPanel.activeInHierarchy)
        {
            int lives = FindObjectOfType<GameSession>().GetCurrentLives();
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
        FindObjectOfType<SceneLoader>().StartGame();
    }

    public void OnOptionsButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<SceneLoader>().LoadOptions();
    }

    public void OnQuitButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<SceneLoader>().Quit();
    }

    public void OnBackButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void OnPlayAgainButtonPressed()
    {
        PlayButtonSound();
        FindObjectOfType<GameSession>().ResetSession();
        FindObjectOfType<SceneLoader>().StartGame();
    }

    public void UpdateHeader(string header)
    {
        headerText.text = header;
    }

    private void PlayButtonSound()
    {
        //TODO: not working (due to changing scenes ?)
        FindObjectOfType<AudioPlayer>().PlaySoundEffect(buttonSound);
    }
}
