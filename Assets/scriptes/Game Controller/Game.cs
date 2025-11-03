using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Game : MonoBehaviour
{
    public static Game instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, GameoverScoreText, GameoverCoinText;
    [SerializeField]
    private GameObject pauesPanel, GameoverPanel;

    [SerializeField]
    private GameObject ready;


    public void SetScore(int Score)
    {
        scoreText.text = "x" + Score;
    }
    public void SetLifeScore(int life)
    {
        lifeText.text = "x" + life;
    }
    public void SetCoinScore(int coin)
    {
        coinText.text = "x" + coin;
    }



    void Awake()
    {
        MakeInstance();
    }

    void Start()
    {
        Time.timeScale = 0f;

    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void GameOverShowPanel(int score, int coin)
    {
        GameoverPanel.SetActive(true);
        GameoverScoreText.text = score.ToString();
        GameoverCoinText.text = coin.ToString();
        StartCoroutine(GameOverLoadMainMenu());

    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("Canvas");
    }
    public void playerdiedrestartgame()
    {
        StartCoroutine(PlayerDiedRestartGame());
    }
    IEnumerator PlayerDiedRestartGame() {
        
        yield return new WaitForSeconds(1f);
        Application.LoadLevel("Play");
    }
    public void PueseGame()
    {
        Time.timeScale = 0f;
        pauesPanel.SetActive(true);

    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauesPanel.SetActive(false);

    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("Canvas");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        ready.SetActive(false);
    }
}
