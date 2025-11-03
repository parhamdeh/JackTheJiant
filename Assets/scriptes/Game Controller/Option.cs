using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    [SerializeField]
    private GameObject easyCheck, mediumCheck, hardCheck;

    void Start()
    { 
        
        SetTheDifficulty();
    }

    void SetIntialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                easyCheck.SetActive(true);
                mediumCheck.SetActive(false);
                hardCheck.SetActive(false);
                break;
            case "medium":
                easyCheck.SetActive(false);
                mediumCheck.SetActive(true);
                hardCheck.SetActive(false);
                break;
            case "hard":
                easyCheck.SetActive(false);
                mediumCheck.SetActive(false);
                hardCheck.SetActive(true);
                break;
        }

    }
    void SetTheDifficulty()
    {
        if (GamePerfences.GetEasyDifficulty() == 1)
        {
            SetIntialDifficulty("easy");
        }
        if (GamePerfences.GetMediumDifficulty() == 1)
        {
            SetIntialDifficulty("medium");
        }
        if (GamePerfences.GetHardDifficulty() == 1)
        {
            SetIntialDifficulty("hard");
        }
    }
    public void EasyDifficulty()
    {
        GamePerfences.SetEasyDifficulty(1);
        GamePerfences.SetMediumDifficulty(0);
        GamePerfences.SetHardDifficulty(0);

        easyCheck.SetActive(true);
        mediumCheck.SetActive(false);
        hardCheck.SetActive(false);
                
    }
    public void MediumDifficulty()
    {
        GamePerfences.SetEasyDifficulty(0);
        GamePerfences.SetMediumDifficulty(1);
        GamePerfences.SetHardDifficulty(0);

        easyCheck.SetActive(false);
        mediumCheck.SetActive(true);
        hardCheck.SetActive(false);
        
    }
    public void HardDifficulty()
    {
        GamePerfences.SetEasyDifficulty(0);
        GamePerfences.SetMediumDifficulty(0);
        GamePerfences.SetHardDifficulty(1);

        easyCheck.SetActive(false);
        mediumCheck.SetActive(false);
        hardCheck.SetActive(true);
        
        
    }
    public void GoMenu()
    {
        Application.LoadLevel("Canvas");

    }
}
