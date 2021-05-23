using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMoving : MonoBehaviour
{
    public GameObject platform;
    public float velocity;
    public float border;
    private bool prawo = true, lewo;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
       if(platform.transform.position.x > border)
        {
            lewo = true;
            prawo = false;
        }
        if (platform.transform.position.x < -border)
        {
            prawo = true;
            lewo = false;
        }
        if(prawo ==true)
        transform.Translate(velocity * Time.deltaTime, 0f, 0f);
        if (lewo == true)
        transform.Translate(-velocity * Time.deltaTime, 0f, 0f);
    }
}
