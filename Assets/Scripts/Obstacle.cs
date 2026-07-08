using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float movementSpeed;
    private int damageValue;
    private int randomDirection;
    private ObstacleSpawner obstacleLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        obstacleLocation = GameObject.Find("ObstacleSpawners").GetComponent<ObstacleSpawner>();
        SpawnedInObstacle();
    }

    /// <summary>
    /// 
    /// </summary>
    void SpawnedInObstacle()
    {
        movementSpeed = Random.Range(5, 20);
        damageValue = Random.Range(1, 6); //Magic numbers, fix later
        randomDirection = Random.Range(1, 5);
    }
    void Update()
    {
        moveObstacle(movementSpeed, randomDirection);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Health stuff
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
    /// 
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
