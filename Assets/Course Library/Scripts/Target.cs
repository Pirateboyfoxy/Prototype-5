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
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector2.up * Random.Range(minSpeed,maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(minTorque,maxTorque),Random.Range(minTorque,maxTorque), Random.Range(minTorque,maxTorque), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
