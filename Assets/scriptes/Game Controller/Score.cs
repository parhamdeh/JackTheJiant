using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField]
    private Text scoreText, coinText;

    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePerfences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePerfences.GetEasyDifficultyScore(), GamePerfences.GetEasyDifficultyCoinScore());
        }
        if (GamePerfences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePerfences.GetEasyMediumDifficultyScore(), GamePerfences.GetMediumDifficultyCoinScore());
        }
        if (GamePerfences.GetHardDifficulty() == 1)
        {
            SetScore(GamePerfences.GetHardDifficultyScor(), GamePerfences.GetHardDifficultyCoinScor());
        }
    }

    public void GoMenu()
    {
        Application.LoadLevel("Canvas");

    }
}
