using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public static bool noJump = false;
    public UnityEvent interactAction;
    
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                interactAction.Invoke();
            }
        }
    }


    // Enter range of trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Sniper Rifle in range");
            isInRange = true;
            noJump = true;
        }
    }

    // Exit range of trigger
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Sniper Rifle out of range");
            isInRange = false;
            noJump = false;
        }
    }
}
