using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject Bullet;
    public float BulletSpeed;
    public AudioSource cannonSound;

    public void ShootRifle()
    {
        cannonSound.Play();
        GameObject BulletInstance = Instantiate(Bullet, transform.position, Quaternion.identity);
        BulletInstance.GetComponent<Rigidbody2D>().AddForce(BulletInstance.transform.right * BulletSpeed);

    }
}
