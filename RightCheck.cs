using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCheck : MonoBehaviour
{
    public Transform rightCheck;
    public float groundRightCheckradious;
    public LayerMask WhatisRightGround;
    private bool R;
    public bool backgrounded=false;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        R = Physics2D.OverlapCircle(rightCheck.position, groundRightCheckradious, WhatisRightGround);
        if (R == true)
            backgrounded = true;
        else
            backgrounded = false;

    }
    void Update()
    {
       
    }
}
