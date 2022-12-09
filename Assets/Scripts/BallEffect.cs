using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : MonoBehaviour
{
    public int particlesPerBurst = 20;
    
    private Ball ball;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        ball = GetComponentInParent<Ball>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        ball.OnBallCollision += BallOnOnBallCollision;
    }

    private void OnDisable()
    {
        ball.OnBallCollision -= BallOnOnBallCollision;
    }
    
    private void BallOnOnBallCollision(Vector2 collisionpoint)
    {
        particleSystem.Emit(particlesPerBurst);
    }
}
