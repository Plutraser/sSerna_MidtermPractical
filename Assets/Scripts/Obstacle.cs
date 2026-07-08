using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float movementSpeed;
    private int damageValue;
    private int randomDirection;

    private float minSpeed = 5f;
    private float maxSpeed = 20f;
    private int minDamage = 1;
    private int maxDamage = 6;
    private int minDirection = 1;
    private int maxDirection = 5;

    private ObstacleSpawner obstacleLocation;
    private PlayerHealth health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleLocation = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
        SpawnedInObstacle();
    }

    /// <summary>
    /// 
    /// </summary>
    void SpawnedInObstacle()
    {
        movementSpeed = Random.Range(minSpeed, maxSpeed);
        damageValue = Random.Range(minDamage, maxDamage);
        randomDirection = Random.Range(minDirection, maxDirection);
    }
    void Update()
    {
        moveObstacle(movementSpeed, randomDirection);
    }

    /// <summary>
    /// If the obstacle collides with the player, it reduces the Player's health by its random damage value, spawns in another object using ObstacleSpawner's method and then destroys itself.
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            health.Health -= damageValue;
            obstacleLocation.GetRandomLocation();
            Destroy(gameObject);
        }
        else
        {
            obstacleLocation.GetRandomLocation();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// The obstacle moving in a random direction based on the random number drawn earlier.
    /// </summary>
    /// <param name="speed"></param>
    void moveObstacle(float speed, int direction)
    {
        switch (direction)
        {
            case 1:
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.back * speed * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                break;
            case 4:
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                break;
            default:
                Debug.Log("Choosing a Random Direction has caused an error.");
                break;
        }
    }
}
