using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject parrot;
    public List<GameObject> obstaclesToSpawn = new List<GameObject>();

    int index;

    void Awake()
    {
        InitObstacles();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObstacle());
    }


    void InitObstacles()
    {
        // initialize obstacles -> the for loop must be greater than all objects that can appear on the screen at the same time, otherwise Unity will collapse because of infinite loop
        // -> Thats is why i < 50 * obstacles.length
        for (int i = 0; i < 50 * obstacles.Length; i++)
        {
            GameObject obj = Instantiate(obstacles[index], transform.position, Quaternion.identity);
            obstaclesToSpawn.Add(obj);
            obstaclesToSpawn[i].SetActive(false);
            index++;

            if (index == obstacles.Length)
            {
                index = 0;
            }
        }
    }

    IEnumerator SpawnRandomObstacle()
    {
        // wait for some time till next obstacle is spawned
        yield return new WaitForSeconds(Random.Range(2f, 3.5f));

        // activate obstacle
        int index = Random.Range(0, obstaclesToSpawn.Count);

        while (true)
        {
            if (Score.score > 2000000)
            {
                // wait for some time till parrot is spawned
                yield return new WaitForSeconds(5f);
                GameObject parrotObject = Instantiate(parrot, transform.position, Quaternion.identity);
                parrotObject.SetActive(true);
                yield return new WaitForSeconds(150f);
            }
            else if (obstaclesToSpawn[index] != null && !obstaclesToSpawn[index].activeInHierarchy)
            {
                obstaclesToSpawn[index].SetActive(true);
                break;
            }
            else
            {
                index = Random.Range(0, obstaclesToSpawn.Count);
            }
        }

        // to always spawn new objects, execute the coroutine again
        StartCoroutine(SpawnRandomObstacle());
    }
}
