using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirateShootingScript : MonoBehaviour
{
    public GameObject[] enemyBullet;
    public List<GameObject> listOfEnemyBullets = new List<GameObject>();

    int index;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyPirateShoot());
    }

    IEnumerator EnemyPirateShoot()
    {
        // wait for some time till next obstacle is spawned
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        GameObject obj = Instantiate(enemyBullet[index], transform.position, Quaternion.identity);
        obj.SetActive(true);
        Debug.Log("Enemy has shot");

        // to always spawn new objects, execute the coroutine again
        StartCoroutine(EnemyPirateShoot());
    }
}
