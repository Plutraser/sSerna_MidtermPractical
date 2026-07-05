using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject[] CoinPrefabs;

    private int initialCoins = 5;

    private float spawnLimitXLeft = -8f;
    private float spawnLimitXRight = 8f;
    private float spawnLimitZUp = 7.8f;
    private float spawnLimitZDown = -8.4f;
    private float yPos = .75f;

    private float spawnDelay = 10f;
    private float spawnInterval;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        for (int i = 0; i < initialCoins; i++)
        {
            int initialCoinsRandomization = Random.Range(0, CoinPrefabs.Length);
            Vector3 initialCoinSpawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), yPos, Random.Range(spawnLimitZDown, spawnLimitZUp));

            Instantiate(CoinPrefabs[initialCoinsRandomization], initialCoinSpawnPos, CoinPrefabs[initialCoinsRandomization].transform.rotation);
        }
        spawnInterval = Random.Range(3, 5f);
        InvokeRepeating("SpawnCoins", spawnDelay, spawnInterval);
    }

    /// <summary>
    /// 
    /// </summary>
    void SpawnCoins()
    {
        int randomization = Random.Range(0, CoinPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), yPos, Random.Range(spawnLimitZDown, spawnLimitZUp));

        Instantiate(CoinPrefabs[randomization], spawnPos, CoinPrefabs[randomization].transform.rotation);
    }
}
