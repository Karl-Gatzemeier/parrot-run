using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;

    public void ShootRifle()
    {
        Debug.Log("Sniper Rifle did shoot");
        GameObject BulletInstance = Instantiate(Bullet, transform.position, Quaternion.identity);
        BulletInstance.GetComponent<Rigidbody2D>().AddForce(BulletInstance.transform.right * BulletSpeed);
    }
}
