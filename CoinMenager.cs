using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinMenager : MonoBehaviour
{
    public static CoinMenager instance;
    public Text text;
    int score;
    void Start()
    {
        if(instance==null)
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeScore(int CoinValue)
    {
        score += CoinValue;
        text.text = "x" + score.ToString();
    }
}
