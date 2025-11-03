using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D target) {
        
    
    
        if (target.tag == "Background2")
        {
            Debug.Log("collide");
            target.gameObject.SetActive(false);


        }
    }










}