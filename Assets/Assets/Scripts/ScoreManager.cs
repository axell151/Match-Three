﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    private static ScoreManager instance = null;
    
    public static ScoreManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
                if(instance = null)
                {
                    Debug.LogError("Fatal Error: ScoreManager not Found");
                }
            }
            return instance;
        }
    }
    #endregion

    public int tileRatio;
    public int comboRatio;
    public int HighScore { get { return highScore; } }
    public int CurrentScore { get { return currentScore; } }

    private int currentScore;
    private int highScore;

    private void Start()
    {
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public void SetHighScore()
    {
        highScore = currentScore;
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);

        SoundManager.Instance.PlayScore(comboCount > 1);
    }
}
