using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision pc;
    public int maxHP = 3;
    public int currentHP;
    public Image h1;
    public Image h2;
    public Image h3;
    public Image hpBanner;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider2d;
    public Animator animator;

    public AudioSource Damage;
    public AudioSource Death;

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

   

    private void LateUpdate()
    {
        animator.SetBool("hit", false);
    }



    //Decreases hp if hit by enemny
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.collider.tag == "EnemyPirate")
        {
            DecreaseHP();
        }
        
    }

    //Decrease HP if hit, should hp be 0 -> game over
    void DecreaseHP()
    {
        animator.SetBool("hit", true);
        currentHP--;

        if (currentHP > 0)
        {
            animator.SetInteger("hp", currentHP);
            removeHeart(currentHP);
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
    }

    void removeHeart(int currentHP)
    {
        if(currentHP == 0)
        {
            Death.Play();
            pc.h1.enabled = false;
            pc.hpBanner.enabled = false;
        }
        if (currentHP == 1)
        {
            Damage.Play();
            pc.h2.enabled = false;
        }
        if (currentHP == 2)
        {
            Damage.Play();
            pc.h3.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "LeftEndDeadCollider")
        {
            while(currentHP > 0)
            {
                DecreaseHP();
            }
        }

        if (other.tag == "parrot")
        {
            // ÄNDERN! Hier muss GameWon() hin!
            while (currentHP > 0)
            {
                DecreaseHP();
            }
        }
    }

}
