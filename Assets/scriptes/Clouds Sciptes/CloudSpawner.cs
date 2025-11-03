using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;

    [SerializeField]
    private GameObject[] collectables;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        controlX = 0;
        SetMinAndMax();
        CreateClouds();
        player = GameObject.FindGameObjectWithTag("Player");
         
         for(int i = 0 ; i< collectables.Length; i++){
            collectables[i].SetActive(false);
         }

    }

    public void Start()
    {
        PositionThePlayer();
    }
    // Update is called once per frame
    void SetMinAndMax()

    // Assets\scriptes\Clouds Sciptes\CloudSpawner.cs(31,38): error CS1061: 'Camera' does not contain a definition for 'ScreenToWorld' and no accessible extension method 'ScreenToWorld' accepting a first argument of type 'Camera' could be found (are you missing a using directive or an assembly reference?)


    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
    // Assets\scriptes\Clouds Sciptes\CloudSpawner.cs(42,25): error CS0019: Operator '<' cannot be applied to operands of type 'int' and 'GameObject[]'


    void Shuffle(GameObject[] arrayToShuffle)
    {
        for (int i = 0; i < arrayToShuffle.Length; i++)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);
            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }

    }

    void CreateClouds()
    {
        Shuffle(clouds);
        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;

            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            // temp.x = Random.Range(minX, maxX);

            lastCloudPositionY = positionY;

            clouds[i].transform.position = temp;

            positionY -= distanceBetweenClouds;
        }
    }

    void PositionThePlayer()
    {
        GameObject[] darkcloud = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] cloudInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkcloud.Length; i++)
        {
            if (darkcloud[i].transform.position.y == 0f)
            {
                Vector3 t = darkcloud[i].transform.position;
                darkcloud[i].transform.position = new Vector3(cloudInGame[0].transform.position.x, cloudInGame[0].transform.position.y, cloudInGame[0].transform.position.z);

                cloudInGame[0].transform.position = t;




            }
        }
        Vector3 temp = cloudInGame[0].transform.position;

        for (int i = 1; i < cloudInGame.Length; i++)
        {
            if (temp.y < cloudInGame[i].transform.position.y)
            {
                temp = cloudInGame[i].transform.position;

            }
        }
        temp.y += 0.8f;
        player.transform.position = temp;

        // float tempY = cloudInGame[0].transform.position.y;
        // for (int i = 1; i < cloudInGame.Length; i++)
        // {
        //     if (tempY < cloudInGame[i].transform.position.y)
        //     {
        //         tempY = cloudInGame[i].transform.position.y;
        //     }
        // }
        // tempY += 0.8f;
        // player.transform.position = new Vector3(player.transform.position.x, tempY, player.transform.position.z);

    }
    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Cloud" || target.tag == "Deadly")
        {
            if (target.transform.position.y == lastCloudPositionY)
            {
                Shuffle(clouds);
                Shuffle(collectables);

                Vector3 temp = target.transform.position;

                for (int i = 0; i < clouds.Length; i++)
                {
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1;
                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2;
                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3;
                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0;
                        }
                        temp.y -= distanceBetweenClouds;
                        lastCloudPositionY = temp.y;
                        


                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);
                        if(clouds[i].tag != "Deadly"){
                            if(!collectables[random].activeInHierarchy){
                                Vector3 temp2 = clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if(collectables[random].tag == "Life"){
                                    if(PlayerScore.lifeCount < 2){
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true);

                                    }
                                }else{
                                        collectables[random].transform.position = temp2;
                                        collectables[random].SetActive(true); 
                                 }
                            }
                        }

                        
                    }
                }
            }
        }
    }
}
