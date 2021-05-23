using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip CoinAudio;
    public static AudioClip JumpSound;
    public static AudioSource audiosource;
    public void Start()
    {
      
        audiosource.clip = JumpSound;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Coin")
        {
            //funkcja tworzy niewidziałny obiekt ktory zniknie po odegraniu audio.
            // gdyby zastosować Play(), obiekt zostałby od razu zniszczony i audio
            //nie byłoby odegrane
            AudioSource.PlayClipAtPoint(CoinAudio, transform.position);
        }
    }
    public static void PlayJump()
    {
        audiosource.Play();
    }
}
