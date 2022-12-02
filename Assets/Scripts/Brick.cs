using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private BrickSpawner spawner;

    public void SetSpawner(BrickSpawner brickSpawner)
    {
        spawner = brickSpawner;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        gameObject.SetActive(false);
        spawner.OnBrickHit(this);
    }
}
