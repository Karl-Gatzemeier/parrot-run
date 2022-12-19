using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //Define Speed Obstacles move at
    [SerializeField] public float speed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        target.Translate(Vector3.left * speed * Time.deltaTime);
    }
}