using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public EdgeCollider2D onEdge;
    public EdgeCollider2D offEdge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(WaitSomeSeconds(collision)); 
    }

    IEnumerator WaitSomeSeconds(Collider2D collision)
    {  
        if(collision.gameObject.tag == "Obstacle")
        {
            SpriteRenderer.color = new Color(0f, 255f, 90f, 0.6f);
        }
        else if(collision.gameObject.tag == "EnemyPirate")
        {
           SpriteRenderer.color = new Color(255f, 0f, 22f, 0.6f);
        }
        yield return new WaitForSeconds(1.6f);
        SpriteRenderer.color = new Color(0.3f, 0.4f, 0f, 0f);
    }
}
