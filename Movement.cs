using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public bool MoveRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0); //ruch
            transform.localScale = new Vector3(1, 1, 1);           //animacja
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Border"))
        {
            if (MoveRight)
                MoveRight = false;                      //gdy uderzy w border zmieni kierunek
            else
                MoveRight = true;

        }
    }
}
