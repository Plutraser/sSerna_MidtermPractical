using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    private ObstacleSpawner obstacleSpawns;
    private CoinSpawner coinSpawns;
    private PlayerHealth health;

    /// <summary>
    /// Initializing all the scripts the score manager will use.
    /// </summary>
    void Start()
    {
        obstacleSpawns = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
        coinSpawns = GameObject.Find("SpawnManager").GetComponent<CoinSpawner>();
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        EndConditions();
    }

    /// <summary>
    /// If the player reaches a score of 50 or above, they win. If their health reaches 0 or below, they lose. Both conditions make obstacles and coins stop spawning.
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

    /// <summary>
    /// Updates the score each time points are added.
    /// </summary>
    public void UpdateScore()
    {
        Debug.Log("New Score: " + Score);
    }
}
