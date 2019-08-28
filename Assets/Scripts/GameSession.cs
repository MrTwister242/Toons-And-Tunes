﻿using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(1, 5)] int startingLives = 3;

    // State
    private int currentLives;
    private int score;

    private void Awake()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;
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
        currentLives = startingLives;
    }

    public int GetScore()
    {
        return score;
    }
    
    public int GetCurrentLives()
    {
        return currentLives;
    }

    public void PlayerDies()
    {
        currentLives--;
        if(currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            //TODO: add a delay
            FindObjectOfType<SceneLoader>().ReloadLevel();
        }
    }

    private void GameOver()
    {
        //TODO: add a delay
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }

    public void Reset()
    {
        Destroy(gameObject);
    }

}