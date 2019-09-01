using System;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(1, 5)] int startingLives = 3;

    // State
    //TODO: make private after debugging
    private int currentLives;
    private float score;
    private bool isDead;


    private void Awake()
    {
        currentLives = startingLives;
        score = 0;
        isDead = false;
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

    public void IncreaseScore(float amount)
    {
        score += amount;
    }

    public float GetScore()
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
            isDead = true;
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

    public void ResetSession()
    {
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return isDead;
    }

}
