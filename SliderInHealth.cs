using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderInHealth : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(float health)
    {
        //pierwsze usatwienie maksymalnego życia
        slider.maxValue = health;
        //ustawienie suwaka na maxa
        slider.value = health;
        //ustawienie koloru na zielony(skala do 0 do 1)
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        //ustawienie zdrowia np bo skuciu się
        slider.value = health;
        //ustawienie coloru suwaga zależnego od dlugosci suwaka
        //normalized- zmiana ze 100 na od 0 do 1
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
