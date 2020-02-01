using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header("Player")]
	public GameObject player;

	// Health
    float shipHealth;
	public bool IsShipDead {
		get {
			return shipHealth <= 0;
		}
	}

	// Time
	float gameplayStartTime;
	float gameTime;


	private void Awake() {
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
    }

    public void DamageShip( float damage )
    {
        shipHealth -= damage;
    }

    
}
