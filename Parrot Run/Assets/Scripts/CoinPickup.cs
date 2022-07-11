using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private int coinValue = 500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("CoinSoundBox").GetComponent<AudioSource>().Play();
            Score.instance.AddCoin();
            Score.instance.AddScore(coinValue);
            Destroy(gameObject);
        }

        if(collision.tag == "ObstacleCollector")
        {
            Destroy(gameObject);
        }
    }
}
