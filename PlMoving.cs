using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlMoving : MonoBehaviour
{
    public GameObject platform;
    public float velocity;
    public float borderright,borderleft;
    private bool prawo = true, lewo;
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (platform.transform.position.x > borderright)
        {
            lewo = true;
            prawo = false;
        }
        if (platform.transform.position.x < borderleft)
        {
            prawo = true;
            lewo = false;
        }
        if (prawo == true)
            transform.Translate(velocity * Time.deltaTime, 0f, 0f);
        if (lewo == true)
            transform.Translate(-velocity * Time.deltaTime, 0f, 0f);
    }
}
