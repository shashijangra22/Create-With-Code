using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManagerScript;
    public ParticleSystem explosionParticle;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;

    private float xRange = 4;
    private float ySpawn = -2;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(GenerateRandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(GenerateRandomTorque(), GenerateRandomTorque(),GenerateRandomTorque(),ForceMode.Impulse);
        transform.position = GenerateRandomPosition();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerScript.GameOver();
        }
    }

    private void OnMouseDown()
    {
        if(gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManagerScript.updateScore(pointValue);
        }

    }

    Vector3 GenerateRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float GenerateRandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 GenerateRandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawn);
    }
}
