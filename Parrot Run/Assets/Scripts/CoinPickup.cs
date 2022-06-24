using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private int coinValue = 1000;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            Score.instance.AddCoin();
            Score.instance.AddScore(coinValue);

        }

        if(collision.tag == "ObstacleCollector")
        {
            Destroy(gameObject);
        }
    }
}
