using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoinConfiguration : MonoBehaviour
{
    // Start is called before the first frame update
    public bool spr1 = true, spr2 = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {

            if (spr1 == true)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);  //zmienia na dane wspolrzedne natomiast funkcja transfor.Rotate(x,y,z) dodaje do wartosci poczatkowej!!
                spr1 = false;
                spr2 = true;
            }

        }
        if (Input.GetKey(KeyCode.A))
        {

            if (spr2 == true)
            {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);   //zmienia na dane wspolrzedne natomiast funkcja transfor.Rotate(x,y,z) dodaje do wartosci poczatkowej!!
                spr2 = false;
                spr1 = true;
            }
        }
    }
}

