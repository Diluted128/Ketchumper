using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Player a;
    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        a.TakeDamage(20);
    }
}
