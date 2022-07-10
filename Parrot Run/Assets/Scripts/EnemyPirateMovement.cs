using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirateMovement : MonoBehaviour
{
    public float accelerationTime = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;
    private Rigidbody2D rb;
    public Animator enemyAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WaitOnSpawn();

    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), 0);
            timeLeft += accelerationTime;
            

        }
    }
    
    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
    }

    IEnumerator WaitOnSpawn()
    {
        yield return new WaitForSeconds(4);
    }
}
