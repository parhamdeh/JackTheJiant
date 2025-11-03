using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public static Manager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;
    void Awake()
    {
        MakeSingleton();
    }
    void Start()
    {
        InitialVaribles();
    }
    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "Play")
        {
            if (gameRestartedAfterPlayerDied)
            {

                Game.instance.SetScore(score);
                Game.instance.SetCoinScore(coinScore);
                Game.instance.SetLifeScore(lifeScore);


                PlayerScore.ScoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else
            {
                PlayerScore.ScoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                Game.instance.SetScore(0);
                Game.instance.SetCoinScore(0);
                Game.instance.SetLifeScore(2);

            }
        }
    }



    void InitialVaribles()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePerfences.SetEasyDifficulty(1);
            GamePerfences.SetEasyDifficultyScore(0);
            GamePerfences.SetEasyDifficultyCoinScore(0);

            GamePerfences.SetMediumDifficulty(0);
            GamePerfences.SetMediumDifficultyScore(0);
            GamePerfences.SetMediumDifficultyCoinScore(0);

            GamePerfences.SetHardDifficulty(0);
            GamePerfences.SetHardDifficultyScor(0);
            GamePerfences.SetHardDifficultyCoinScor(0);

            GamePerfences.SetIsMusicOn(0);
            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CheckGameStatus(int score, int coinscore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            // easy
            if (GamePerfences.GetEasyDifficulty() == 1)
            {
                int highScore = GamePerfences.GetEasyDifficultyScore();
                int coinScore = GamePerfences.GetEasyDifficultyCoinScore();

                if (highScore < score)
                {
                    GamePerfences.SetEasyDifficultyScore(score);
                }
                if (coinScore < coinscore)
                {
                    GamePerfences.SetEasyDifficultyCoinScore(coinscore);
                }
                // medium

            }
            if (GamePerfences.GetMediumDifficulty() == 1)
            {
                int highScore = GamePerfences.GetEasyMediumDifficultyScore();
                int coinScore = GamePerfences.GetMediumDifficultyCoinScore();

                if (highScore < score)
                {
                    GamePerfences.SetMediumDifficultyScore(score);
                }
                if (coinScore < coinscore)
                {
                    GamePerfences.SetMediumDifficultyCoinScore(coinscore);
                }
                
            }
            // hard
            if (GamePerfences.GetHardDifficulty() == 1)
            {
                int highScore = GamePerfences.GetHardDifficultyScor();
                int coinScore = GamePerfences.GetHardDifficultyCoinScor();

                if (highScore < score)
                {
                    GamePerfences.SetHardDifficultyScor(score);
                }
                if (coinScore < coinscore)
                {
                    GamePerfences.SetHardDifficultyCoinScor(coinscore);
                }

            }



            gameRestartedAfterPlayerDied = false;
            gameStartedFromMainMenu = false;

            Game.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinscore;
            this.lifeScore = lifeScore;


            Game.instance.SetScore(score);
            Game.instance.SetCoinScore(coinscore);
            Game.instance.SetLifeScore(lifeScore);

            gameRestartedAfterPlayerDied = true;
            gameStartedFromMainMenu = false;

            Game.instance.playerdiedrestartgame();

        }
    }

    
}
