using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text coinText;
    
    int score = 0;
    int coins = 0;

    private void Awake()
    {
        instance = this;
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
        score += value;
        scoreText.text = score.ToString();
    }

}
