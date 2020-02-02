using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header( "Player" )]
    public GameObject player;

    
    // Health
    float shipHealth;
    public bool IsShipDead
    {
        get
        {
            return shipHealth <= 0;
        }
    }

    // Points
    public int points;

    // Time
    float gameplayStartTime;
    public float gameTime;

    // UI
    public Slider shipHealthUI;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameplayStartTime = Time.realtimeSinceStartup;
        gameTime = 0;
        points = 0;

        shipHealth = 1.0f;
    }

    void Update()
    {
        shipHealthUI.value = shipHealth;

        if( IsShipDead )
        {
            Time.timeScale = 0;
        }
        else
        {
            gameTime = Time.realtimeSinceStartup - gameplayStartTime;
        }
    }

    public void DamageShip( float damage )
    {
        shipHealth -= damage;
    }

    public void AddPoints( int newPoints )
    {
        points += newPoints;
    }
}
