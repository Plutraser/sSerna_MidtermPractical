using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private float rotationSpeed = 80f;
    [SerializeField] private float bobSpeed = 2f;
    private float heightLimit = 2;
    private float floorLimit = 0.5f;
    private float startDelay = 0.2f;
    private float repeatRate;
    private bool isOnFloor = false;

    private ScoreManager scoreManagerScript;

    void Start()
    {
        scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        InvokeRepeating("RotatingCoinAnimation", startDelay, repeatRate);
        InvokeRepeating("BobbingCoinAnimation", startDelay, repeatRate);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManagerScript.Score += points;
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void RotatingCoinAnimation()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);     
    }

    /// <summary>
    /// 
    /// </summary>
    private void BobbingCoinAnimation()
    {
        if (transform.position.y <= floorLimit)
        {
            isOnFloor = true;
        }
        if (transform.position.y >= heightLimit)
        {
            isOnFloor = false;
        }
        if (isOnFloor == true)
        {
            transform.Translate(Vector3.back * bobSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * bobSpeed * Time.deltaTime);
        }
    }
    

}
