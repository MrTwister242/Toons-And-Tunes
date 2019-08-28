﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] TMPro.TextMeshProUGUI headerText;

    // State
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
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

    public void UpdatesLivesDisplay()
    {
        //TODO: implement lives display
    }

}