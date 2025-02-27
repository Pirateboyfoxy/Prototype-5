using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    Rigidbody targetRb;

    float minSpeed = 12;
    float maxSpeed = 20;
    float minTorque = -10;
    float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector2.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(minTorque,maxTorque),Random.Range(minTorque,maxTorque), Random.Range(minTorque,maxTorque), ForceMode.Impulse);
        transform.position = RandomSpawmPos();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(minTorque, maxTorque);
    }
    
    Vector3 RandomSpawmPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        if (gameManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
