using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPirateShootingScript : MonoBehaviour
{
    public GameObject[] enemyBullet;
    public List<GameObject> listOfEnemyBullets = new List<GameObject>();

    int index;

    void Awake()
    {
        InitObstacles();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyPirateShoot());
    }

    void InitObstacles()
    {
        // initialize obstacles -> the for loop must be greater than all objects that can appear on the screen at the same time, otherwise Unity will collapse because of infinite loop
        // -> Thats is why i < 50 * obstacles.length
        for (int i = 0; i < 50 * enemyBullet.Length; i++)
        {
            listOfEnemyBullets.Add(enemyBullet[index]);
            index++;

            if (index == enemyBullet.Length)
            {
                index = 0;
            }
        }
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

    IEnumerator EnemyPirateShoot2()
    {
        // wait for some time till next obstacle is spawned
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        // activate obstacle
        int index = Random.Range(0, listOfEnemyBullets.Count);

        while (true)
        {

            if (listOfEnemyBullets[index] != null)
            {
                GameObject obj = Instantiate(listOfEnemyBullets[index], transform.position, Quaternion.identity);
                obj.SetActive(true);
                Debug.Log("Enemy has shot");
                break;
            }
            else
            {
                index = Random.Range(0, listOfEnemyBullets.Count);
            }
        }

        // to always spawn new objects, execute the coroutine again
        StartCoroutine(EnemyPirateShoot2());
    }
}
