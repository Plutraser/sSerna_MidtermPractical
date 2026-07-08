using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    private ObstacleSpawner obstacleSpawns;
    private CoinSpawner coinSpawns;
    private PlayerHealth health;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        obstacleSpawns = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
        coinSpawns = GameObject.Find("CoinSpawner").GetComponent<CoinSpawner>();
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        EndConditions();
    }

    /// <summary>
    /// 
    /// </summary>
    void EndConditions()
    {
        if (Score >= 50)
        {
            Destroy(obstacleSpawns);
            Destroy(coinSpawns);
            Debug.Log("You WIN.");
        }
        if (health.Health <= 0)
        {
            Destroy(obstacleSpawns);
            Destroy(coinSpawns);
            Debug.Log("You LOSE.");
        }
    }
}
