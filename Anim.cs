using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public static Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public static void Running(bool statment)
    {

        if (statment)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }

}
