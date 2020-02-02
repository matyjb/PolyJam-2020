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

        shipHealth = 1.0f;
    }

    void Update()
    {
        gameTime = Time.realtimeSinceStartup - gameplayStartTime;

        shipHealthUI.value = shipHealth;
    }

    public void DamageShip( float damage )
    {
        shipHealth -= damage;
    }
}
