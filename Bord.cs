using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bord : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 screeenBounds;
    void Start()
    {
        screeenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 wektor = transform.position;
        wektor.x = Mathf.Clamp(wektor.x, screeenBounds.x, screeenBounds.x * -1);
        wektor.y = Mathf.Clamp(wektor.y, screeenBounds.y, screeenBounds.y * -1);
        transform.position = wektor;
    }
}