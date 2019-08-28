using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // State
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void OnStartButtonPressed()
    {
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
}
