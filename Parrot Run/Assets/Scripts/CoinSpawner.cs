using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] coins;
    public List<GameObject> coinsToSpawn = new List<GameObject>();

    int index;

    void Awake()
    {
        InitCoins();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomCoin());
    }

    void InitCoins()
    {
        // initialize coins -> the for loop must be greater than all coins that can appear on the screen at the same time, otherwise Unity will collapse because of infinite loop
        // -> Thats is why i < 50 * coins.length
        for (int i = 0; i < 50 * coins.Length; i++)
        {
            GameObject obj = Instantiate(coins[index], transform.position, Quaternion.identity);
            coinsToSpawn.Add(obj);
            coinsToSpawn[i].SetActive(false);
            index++;

            if (index == coins.Length)
            {
                index = 0;
            }
        }
    }


    IEnumerator SpawnRandomCoin()
    {
        // wait for some time till next coin is spawned
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        // activate coin
        int index = Random.Range(0, coinsToSpawn.Count);

        while (true)
        {
            if (coinsToSpawn[index] != null && !coinsToSpawn[index].activeInHierarchy)
            {
                coinsToSpawn[index].SetActive(true);
                break;
            }
            else
            {
                index = Random.Range(0, coinsToSpawn.Count);
            }
        }

        // to always spawn new coins, execute the coroutine again
        StartCoroutine(SpawnRandomCoin());
    }
}
