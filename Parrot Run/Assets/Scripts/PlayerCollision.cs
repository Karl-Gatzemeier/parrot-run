using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision pc;
    public int maxHP = 3;
    public int currentHP;
    public bool hit = false;
    public Image h1;
    public Image h2;
    public Image h3;
    public Image hpBanner;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider2d;
    public Animator animator;

    private void Awake()
    {
        pc = this;
        body = GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            DecreaseHP();
        }
    }

    private void LateUpdate()
    {
        hit = false;
        animator.SetBool("hit", false);
    }

    //Decrease HP if hit, should hp be 0 -> game over
    void DecreaseHP()
    {
        hit = true;
        animator.SetBool("hit", true);
        currentHP--;

        if (currentHP > 0)
        {
            animator.SetInteger("hp", currentHP);
            removeHeart(currentHP);
            Debug.Log(currentHP);
        }
        else
        {
            removeHeart(currentHP);
            animator.SetInteger("hp", currentHP);
            GameOver();
        }
    }
    void GameOver()
    {
        GameOverScreen.gameOver = true;
        Debug.Log("Deadge");
    }

    void removeHeart(int currentHP)
    {
        if(currentHP == 0)
        {
            pc.h1.enabled = false;
            pc.hpBanner.enabled = false;
        }
        if (currentHP == 1)
        {
            pc.h2.enabled = false;
        }
        if (currentHP == 2)
        {
            pc.h3.enabled = false;
        }
    }

}
