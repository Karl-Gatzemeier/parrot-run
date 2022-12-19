using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static Score instance;
    public Text scoreText;
    public Text coinText;
    public Text finalScore;
    public Text finalCoins;
    public Text winningScore;
    public Text winningCoins;
    public Image coinImage;
    
    public static int score;
    public static int coins;

    private void Awake()
    {
        instance = this;
        score = 0;
        coins = 0;

    }

    void Start()
    {
        instance.scoreText.text = score.ToString();
        instance.coinText.text = "x" + coins.ToString();

    }

    private void Update()
    {
            AddScore(1); 
    }

    public void AddCoin()
    {
        coins += 1;
        instance.coinText.text = "x" + coins.ToString();
    }

    public void AddScore(int value)
    {
        //Only Add Score Points while Game is not paused or over
        if (!PauseMenu.isPaused && !GameOverScreen.gameOver && !EndScreen.foundParrot) {
            score += value;
            instance.scoreText.text = score.ToString();
        }
    }

    //Function is Called when GameOverScreen is displayed
    public void ShowFinalScore()
    {
        instance.scoreText.text = "";
        instance.coinText.text = "";
        instance.coinImage.enabled = false;
        instance.finalScore.text = "Score: " + score.ToString();
        instance.finalCoins.text = "Coins: " + coins.ToString();
    }

    public void ShowWinningScore()
    {
        instance.scoreText.text = "";
        instance.coinText.text = "";
        instance.coinImage.enabled = false;
        instance.winningScore.text = "Final Score: " + score.ToString();
        instance.winningCoins.text = "Coins collected: " + coins.ToString();
    }

}
