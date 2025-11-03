using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    [SerializeField]
    private Button musicBtn;
    [SerializeField]
    private Sprite[] musicIcons;

    void Start()
    {
        checktheplayedmusic();
    }


    void checktheplayedmusic()
    {
        if (GamePerfences.GetIsMusicOn() == 1)
        {
            MusicControler.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }else{
            MusicControler.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];

        }
    }
    public void StartGame()
    {
        Application.LoadLevel("Play");

    }
    public void HighScore()
    {
        Application.LoadLevel("Score");

    }
    public void Options()
    {
        Application.LoadLevel("Option Menu");

    }
    public void Quit()
    {
        Application.Quit();

    }
    public void Music()
    {
        if (GamePerfences.GetIsMusicOn() == 0){
            GamePerfences.SetIsMusicOn(1);
            MusicControler.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];

        }else if(GamePerfences.GetIsMusicOn() == 1){
            GamePerfences.SetIsMusicOn(0);
            MusicControler.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }
}