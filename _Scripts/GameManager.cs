using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;    private bool _isGameOver = false;
    private bool _isGameWon = false;
    public bool _gameStarted = false;

    // Use this for initialization
    void Start()
    {
        Singleton();
    }


    // *********************
    // Getters
    // *********************
    public bool IsGameStarted()
    {
        return _gameStarted;
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

    public bool IsGameWon()
    {
        return _isGameWon;
    }


    // *********************
    // Actions
    // *********************
    public void GameOver()
    {
        //Load Game Over screen
    }

    public void GameWon()
    {
        //Load Won screen
    }


    // ********************
    // Singleton
    // ********************
    void Singleton()
    {
        if (instance != this || instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
