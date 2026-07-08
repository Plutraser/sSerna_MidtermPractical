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
    /// Invokes the coin animations, bobbing and rotating.
    /// </summary>
    void Update()
    {
        InvokeRepeating("RotatingCoinAnimation", startDelay, repeatRate);
        InvokeRepeating("BobbingCoinAnimation", startDelay, repeatRate);
    }

    /// <summary>
    /// If the coin collides with the Player, it adds points to the score, calls upon a method in Scoremanager and then destroys itself.
    /// </summary>
    /// <param name="other"></param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManagerScript.Score += points;
            scoreManagerScript.UpdateScore();
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Rotates the coin
    /// </summary>
    private void RotatingCoinAnimation()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);     
    }

    /// <summary>
    /// bobs the coin up and down, if it reaches the height limit it goes down and if it reaches the floor limit, it goes back up.
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
