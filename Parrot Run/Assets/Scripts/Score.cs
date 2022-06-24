using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text coinText;
    
    static int score;
    static int coins;

    private void Awake()
    {
        instance = this;
        score = 0;
        coins = 0;

    }

    void Start()
    {
        scoreText.text = score.ToString();
        coinText.text = "x" + coins.ToString();

    }

    private void Update()
    {
            AddScore(1); 
    }

    public void AddCoin()
    {
        coins += 1;
        coinText.text = "x" + coins.ToString();
    }

    public void AddScore(int value)
    {
        if (!PauseMenu.isPaused) {
            score += value;
            scoreText.text = score.ToString();
        }
    }

}
