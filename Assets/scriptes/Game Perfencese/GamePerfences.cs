using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePerfences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";


    public static string EasyDifficultyScore = "EasyDifficultyScore";
    public static string MediumDifficultyScore = "MediumDifficultyScore";
    // ...
    public static string HardDifficultyScor = "HardDifficultyScor";


    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    // ....
    public static string HardDifficultyCoinScor = "HardDifficultyCoinScor";

    public static string IsMusicOn = "IsMusicOn";



    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(GamePerfences.IsMusicOn);
    }
    public static void SetIsMusicOn(int state)
    {
        PlayerPrefs.SetInt(GamePerfences.IsMusicOn, state);

    }
    // getter and setter for EasyDifficulty
    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePerfences.EasyDifficulty);
    }
    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.EasyDifficulty, difficulty);

    }
    // getter and setter for MediumDifficulty

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(GamePerfences.MediumDifficulty);
    }
    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.MediumDifficulty, difficulty);

    }
    // getter and setter for HardDifficulty

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePerfences.HardDifficulty);
    }
    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.HardDifficulty, difficulty);

    }
    // getter and setter for EasyDifficultyScore

    public static int GetEasyDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePerfences.EasyDifficultyScore);
    }
    public static void SetEasyDifficultyScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.EasyDifficultyScore, difficulty);

    }
    // getter and setter for MediumDifficultyScore
    public static int GetEasyMediumDifficultyScore()
    {
        return PlayerPrefs.GetInt(GamePerfences.MediumDifficultyScore);
    }
    public static void SetMediumDifficultyScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.MediumDifficultyScore, difficulty);

    }

    // getter and setter for HardDifficultyScor
    public static int GetHardDifficultyScor()
    {
        return PlayerPrefs.GetInt(GamePerfences.HardDifficultyScor);
    }
    public static void SetHardDifficultyScor(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.HardDifficultyScor, difficulty);

    }

    // getter and setter for EasyDifficultyCoinScore
    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePerfences.EasyDifficultyCoinScore);
    }
    public static void SetEasyDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.EasyDifficultyCoinScore, difficulty);

    }
    
    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePerfences.MediumDifficultyCoinScore);
    }
    public static void SetMediumDifficultyCoinScore(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.MediumDifficultyCoinScore, difficulty);

    }
    public static int GetHardDifficultyCoinScor()
    {
        return PlayerPrefs.GetInt(GamePerfences.HardDifficultyCoinScor);
    }
    public static void SetHardDifficultyCoinScor(int difficulty)
    {
        PlayerPrefs.SetInt(GamePerfences.HardDifficultyCoinScor, difficulty);

    }



}