using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    PlayerController playerController;
    private void Start() 
    {
        playerController = FindObjectOfType<PlayerController>();    
    }
    public enum PowerupType
    {
        AddBall,
        ExplosionBall,
        MultiplyBall
    }
    public PowerupType type;

    private void OnTriggerEnter(Collider other) 
    {
        switch(type)
        {
            case PowerupType.AddBall:
                playerController.AddBall();
                break;
            case PowerupType.ExplosionBall:
                playerController.ExplosionBall();
                break;
            case PowerupType.MultiplyBall:
                BallController ballController = other.gameObject.GetComponent<BallController>();
                if(ballController)
                {
                    ballController.MultiplyBall();
                }
                break;
        }
    }
}
