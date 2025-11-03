using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{

    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        SetMinAndMax();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }

        if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }

    }
    // Assets\scriptes\Player Scriptes\PlayerBounds.cs(36,38): error CS1061: 'Camera' does not contain a definition for 'ScreenToworldPoint' and no accessible extension method 'ScreenToworldPoint' accepting a first argument of type 'Camera' could be found (are you missing a using directive or an assembly reference?)

    void SetMinAndMax()
    {
        // Screen.width
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        maxX = bounds.x;
        minX = -bounds.x;
    }
}
