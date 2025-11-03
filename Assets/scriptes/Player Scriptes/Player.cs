using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVlocity = 4f;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }
    // Update is called once per frame

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal");


        if (h > 0)
        {
            if (vel < maxVlocity)
            {
                forceX = speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            anim.SetBool("walk", true);
        }
        else if (h < 0)
        {
            if (vel < maxVlocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;

            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
// Assets\scriptes\Player Scriptes\Player.cs(33,38): error CS1061: 'Rigidbody2D' does not contain a definition for 'maxVlocity' and no accessible extension method 'maxVlocity' accepting a first argument of type 'Rigidbody2D' could be found (are you missing a using directive or an assembly reference?)


        myBody.AddForce(new Vector2(forceX, 0));
    }
    void Update()
    {
        
    }
}
