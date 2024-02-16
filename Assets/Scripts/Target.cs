using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 13.0f;
    private float maxSpeed = 20.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;
    // Start is called before the first frame update
    void Start()
    {
        //capture the rigidbody
        targetRb = GetComponent<Rigidbody>();
        //give the rigidbody random force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //Rotate the target with a random rotation on eath axis
        targetRb.AddTorque(RandomTorque(),
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse);
        //set the position of the target to a random position
        transform.position = RandomSpawnPos();
    }
    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos, 0);
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
