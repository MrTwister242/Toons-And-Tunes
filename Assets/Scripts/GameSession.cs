using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(1, 5)] int startingLives = 3;

    // State
    private int currentLives;

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

    public void Start()
    {
        currentLives = startingLives;
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
            throw new NotImplementedException();
        }
    }

    private void GameOver()
    {
        throw new NotImplementedException();
    }
}
