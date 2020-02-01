using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float shipHealth;
    public bool shipDead;

    float gameplayStartTime;
    public float gameTime;

    Vector2 holeSpawnArea = new Vector2( 5f, 2f );
    public GameObject holePrefab;


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

        // Temp debug
        if( Input.GetKeyDown( KeyCode.K ) )
            SpawnRandomHole();
    }

    public void DamageShip( float damage )
    {
        shipHealth -= damage;
    }

    bool IsShipDead()
    {
        return shipHealth <= 0;
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
