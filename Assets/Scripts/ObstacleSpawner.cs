using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    private Transform obstacleSpawnLocations;
    private int maxLocations = 5;
    public int RandomLocation = 1;

    private float spawnDelay = .2f;
    private float spawnInterval = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnInterval = Random.Range(3, 5f);
        InvokeRepeating("GetRandomLocation", spawnDelay, spawnInterval);
    }

    /// <summary>
    /// Gets a random spawn location for the obstacles. Because of a bug, I made sure that it cannot spawn another obstacle while one is still active. If there is no other object in the scene,
    /// It spawns in an obstacle.
    /// </summary>
    public void GetRandomLocation()
    {
        RandomLocation = Random.Range(1, maxLocations);
        GameObject obstacleActive = GameObject.FindWithTag("Obstacle");

        switch (RandomLocation)
        {
            case 1:
                obstacleSpawnLocations = transform.Find("ObstacleSpawner1");
                if (obstacleActive != null)
                {
                    break;
                }
                else
                {
                    Instantiate(ObstaclePrefab, obstacleSpawnLocations.position, ObstaclePrefab.transform.rotation);
                }
                break;
            case 2:
                obstacleSpawnLocations = transform.Find("ObstacleSpawner2");
                if (obstacleActive != null)
                {
                    break;
                }
                else
                {
                    Instantiate(ObstaclePrefab, obstacleSpawnLocations.position, ObstaclePrefab.transform.rotation);
                }
                break;
            case 3:
                obstacleSpawnLocations = transform.Find("ObstacleSpawner3");
                if (obstacleActive != null)
                {
                    break;
                }
                else
                {
                    Instantiate(ObstaclePrefab, obstacleSpawnLocations.position, ObstaclePrefab.transform.rotation);
                }
                break;
            case 4:
                obstacleSpawnLocations = transform.Find("ObstacleSpawner4");
                if (obstacleActive != null)
                {
                    break;
                }
                else
                {
                    Instantiate(ObstaclePrefab, obstacleSpawnLocations.position, ObstaclePrefab.transform.rotation);
                }
                break;
            default:
                Debug.Log("No location found.");
                break;
        }
    }
}
