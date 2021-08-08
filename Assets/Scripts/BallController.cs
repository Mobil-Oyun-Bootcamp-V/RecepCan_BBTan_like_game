using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float randomFactor = 0.2f;
    Rigidbody rigidBody;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        float randomFactorX = Random.Range(-randomFactor, randomFactor);
        float randomFactorY = Random.Range(-randomFactor, randomFactor);
        Vector3 velocityTweak = new Vector3(randomFactorX, 0, randomFactorY);
        rigidBody.velocity += velocityTweak;
    }
    public void MultiplyBall()
    {
        //TODO
    }
}
