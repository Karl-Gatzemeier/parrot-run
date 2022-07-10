using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parrot : MonoBehaviour
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
        if (transform.position.x > 0)
        {
            target.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
