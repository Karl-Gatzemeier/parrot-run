using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingSound : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
