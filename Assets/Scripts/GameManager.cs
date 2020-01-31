using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float shipHealth;
    public bool shipDead;

    float gameplayStartTime;
    public float gameTime;


    void Start()
    {
        gameplayStartTime = Time.realtimeSinceStartup;
        gameTime = 0;
        shipDead = false;

        shipHealth = 1.0f;
    }

    void Update()
    {
        gameTime = Time.realtimeSinceStartup - gameplayStartTime;

        shipDead = IsShipDead();
    }

    public void DamageShip( float damage )
    {
        shipHealth -= damage;
    }

    bool IsShipDead()
    {
        return shipHealth <= 0;
    }
}
