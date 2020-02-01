using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	[Header("Player")]
	public GameObject player;

    Vector2 holeSpawnArea = new Vector2( 5f, 2f );
    public GameObject holePrefab;
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


    void Start()

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

    
    void SpawnRandomHole()
    {
        Vector2 randomPos;
        Vector2 colliderOffset = holePrefab.GetComponent<CircleCollider2D>().offset;
        float circleRadius = holePrefab.GetComponent<CircleCollider2D>().radius * 1.2f;

        Collider2D collision = null;
        GameObject hole = null;

        for( int i = 0; hole == null && i < 50; ++i )
        {
            randomPos = new Vector2( 
                Random.Range( -holeSpawnArea.x, holeSpawnArea.x ), 
                Random.Range( -holeSpawnArea.y, holeSpawnArea.y ) );
            collision = Physics2D.OverlapCircle( randomPos + colliderOffset, circleRadius );

            if( collision == null )
            {
                hole = Instantiate( holePrefab, randomPos, holePrefab.transform.rotation );
            }
        }
    }
}
