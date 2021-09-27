using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    #region Singleton
    private static GameFlowManager instance = null;
    public static GameFlowManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameFlowManager>();
                if (instance == null)
                {
                    Debug.LogError("Fatal Error: GameFlowManager not Found!");
                }
            }
            return instance;
        }
    }
    #endregion


    [Header("UI")]
    public UIGameOver GameOverUI;

    public bool IsGameOver { get { return isGameOver; } }
    private bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        ScoreManager.Instance.SetHighScore();
        GameOverUI.Show();
    }
}
