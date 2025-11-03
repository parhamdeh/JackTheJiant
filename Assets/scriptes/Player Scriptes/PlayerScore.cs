using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;
    private GameScript cameraScript;


    private Vector3 preiviousPosition;
    private bool countScore;

    public static int lifeCount;
    public static int ScoreCount;
    public static int  coinCount ;

    public static int lifeScore;
    

    void Awake() {
        cameraScript = Camera.main.GetComponent<GameScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        preiviousPosition = transform.position;
        countScore = true;

    }

    // Update is called once per frame
    void Update()
    {
        CounteScore();
    }

    void CounteScore(){
        if(countScore){
            if (transform.position.y < preiviousPosition.y)
            {
                ScoreCount++;
                
                Game.instance.SetScore(ScoreCount);
            


            }
            preiviousPosition = transform.position;
            
        }
    }
    void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Coin"){
            coinCount++;
            ScoreCount += 200;

            Game.instance.SetScore(ScoreCount);
            Game.instance.SetCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            target.gameObject.SetActive(false);

        }
        if (target.tag == "Life"){
            lifeCount++;
            ScoreCount += 200;

            Game.instance.SetScore(ScoreCount);
            Game.instance.SetLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            target.gameObject.SetActive(false);

        }
        if (target.tag == "Bounds" || target.tag == "Deadly")
        {
            cameraScript.moveCamera = false;
            countScore = false;

            // Game.instance.GameOverShowPanel(ScoreCount, coinCount);

            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            Manager.instance.CheckGameStatus(ScoreCount, coinCount, lifeCount);

        }
        // if (target.tag == "Deadly"){
        //     cameraScript.moveCamera = false;
        //     countScore = false;

        //     // Game.instance.GameOverShowPanel(ScoreCount, coinCount);

        //     transform.position = new Vector3 (500, 500, 0);
        //     lifeCount--;
        //     Manager.instance.CheckGameStatus(ScoreCount, coinCount, lifeCount);
        // }

    }
}

