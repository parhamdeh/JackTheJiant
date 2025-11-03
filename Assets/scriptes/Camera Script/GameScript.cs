using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easyspeed = 3.2f;
    private float mediumspeed = 3.7f;
    private float hardspeed = 4.7f;
    // Start is called before the first frame update
    [HideInInspector]
    public bool moveCamera;
    void Start()
    {
        if (GamePerfences.GetEasyDifficulty() == 1)
        {
            maxSpeed = easyspeed;
        }
        if (GamePerfences.GetMediumDifficulty() == 1)
        {
            maxSpeed = mediumspeed;
        }
        if (GamePerfences.GetHardDifficulty() == 1)
        {
            maxSpeed = hardspeed;
        }
        moveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCamera){
            MoveCamera();
        }
        
    }

    void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;
        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}
