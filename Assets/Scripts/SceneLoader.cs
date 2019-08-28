using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // configuration
    [SerializeField] [Range(0, 20)] int flashScreenTime = 4;

    // state
    private int currentSceneIndex;

    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<SceneLoader>().Length;
        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(TransitionToMainMenu());
        }
    }

    IEnumerator TransitionToMainMenu()
    {
        yield return new WaitForSeconds(flashScreenTime);
        LoadMainMenu();
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNextLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(sceneIndex + 1);
    }

    public void ReloadLevel()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        LoadScene(sceneIndex);
    }

    public void StartGame()
    {
        LoadScene(3);
    }

    public void LoadOptions()
    {
        LoadScene(2);
    }

    public void LoadMainMenu()
    {
        LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
