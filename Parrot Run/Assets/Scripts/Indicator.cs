using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public EdgeCollider2D onEdge;
    public EdgeCollider2D offEdge;

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
        }
        else if(collider.gameObject.tag == "MovingObstacle")
        {
            Debug.Log("Hit");
        }
    }
    
    
}
