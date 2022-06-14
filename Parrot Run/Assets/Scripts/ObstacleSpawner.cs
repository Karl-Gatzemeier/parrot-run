using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject[] obstacles;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitObstacles()
    {
        // initialize obstacles
        for (int i = 0; i < obstacles.Length; i++)
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
            if (!obstaclesToSpawn[index].activeInHierarchy)
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
