using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Running(bool statment)
    {
        if (statment)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);


    }
}
